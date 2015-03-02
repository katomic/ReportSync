namespace ReportSync
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.IO;
	using System.Windows.Forms;
	using Properties;
	using ReportService;

	public partial class ReportSync : Form
	{
		private const string ROOT_FOLDER = "/";
		private const string PATH_SEPERATOR = "/";
		private const string SOURCE_SELECTION_START = "ReportSyncSource:";
		private const string DEST_SELECTION_START = "ReportSyncDest:";
		private const string MAPPING_START = "ReportSyncMap:";

		private readonly ServiceWrapper _SourceService;
		private readonly ServiceWrapper _DestinationService;

		private Dictionary<string, string> destDS;
		private ReportingService2005 destRS;
		private List<string> existingPaths;
		private string pathOnDisk;

		private int processedNodeCount;
		private int selectedNodeCount;
		private Dictionary<string, string> sourceDS;
		private ReportingService2005 sourceRS;
		private string uploadPath = ROOT_FOLDER;
		private BackgroundWorker _SyncSchedulesWorker;

		public ReportSync()
		{
			InitializeComponent();

			_SourceService = new ServiceWrapper();
			_DestinationService = new ServiceWrapper();

			bwDownload.DoWork += bwDownload_DoWork;
			bwDownload.ProgressChanged += bwDownload_ProgressChanged;
			bwDownload.RunWorkerCompleted += bwDownload_RunWorkerCompleted;

			bwUpload.DoWork += bwUpload_DoWork;
			bwUpload.ProgressChanged += bwUpload_ProgressChanged;
			bwUpload.RunWorkerCompleted += bwUpload_RunWorkerCompleted;

			bwSync.DoWork += bwSync_DoWork;
			bwSync.ProgressChanged += bwSync_ProgressChanged;
			bwSync.RunWorkerCompleted += bwSync_RunWorkerCompleted;

			_SyncSchedulesWorker = new BackgroundWorker();
			_SyncSchedulesWorker.DoWork += bwSyncSchedules_DoWork;
			_SyncSchedulesWorker.ProgressChanged += bwSyncSchedules_ProgressChanged;
			_SyncSchedulesWorker.RunWorkerCompleted += bwSyncSchedules_RunWorkerCompleted;
		}

		#region Events

		private void btnLoad_Click(object sender, EventArgs e)
		{
			LoadSourceTree();
		}

		private void btnDestLoad_Click(object sender, EventArgs e)
		{
			LoadDestinationTree();
		}

		private void OnNodeChecked(object sender, TreeViewEventArgs e)
		{
			if (e.Action == TreeViewAction.Unknown)
			{
				return;
			}

			var node = e.Node;
			var isChecked = node.Checked;
			if (isChecked)
			{
				var parent = node.Parent;
				while (parent != null)
				{
					parent.Checked = true;
					parent = parent.Parent;
				}
			}

			if (node.Nodes.Count > 0)
			{
				if (!isChecked || !node.IsExpanded)
				{
					UpdateSelection(node, node.Checked);
				}
			}
		}

		private void aboutReportSyncToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frmAbout = new AboutReportSync();
			frmAbout.Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(@"http://code.google.com/p/reportsync/wiki/");
		}

		#endregion

		#region Utilities

		private void UpdateSelection(TreeNode node, bool isChecked)
		{
			node.Checked = isChecked;

			foreach (TreeNode child in node.Nodes)
			{
				UpdateSelection(child, isChecked);
			}
		}

		private void UpdateSelections(TreeNodeCollection nodes, bool isChecked)
		{
			foreach (TreeNode node in nodes)
			{
				UpdateSelection(node, isChecked);
			}
		}

		private void UpdateProgress(BackgroundWorker backgroundWorker, int currentItem, int totalItems)
		{
			var progress = totalItems > 0 ? (currentItem * 100.0) / totalItems : 0;
			backgroundWorker.ReportProgress((int)progress);
		}

		private void AddSelectedItems(TreeNodeCollection nodes, List<TreeNode> selectedNodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (!node.Checked)
				{
					continue;
				}

				selectedNodes.Add(node);

				var childNodes = node.Nodes;
				if (childNodes.Count > 0)
				{
					AddSelectedItems(childNodes, selectedNodes);
				}
			}
		}

		private void ProcessItems(TreeNodeCollection nodes, BackgroundWorker worker, Action<ReportItem> loadAction, Action<ReportItem> saveAction)
		{
			var selectedNodes = new List<TreeNode>();
			AddSelectedItems(nodes, selectedNodes);

			var selectedNodeCount = selectedNodes.Count;
			if (selectedNodeCount > 0)
			{
				var nodesProcessed = 0;

				foreach (var node in selectedNodes)
				{
					var item = node.Tag as ReportItem;
					if (item != null)
					{
						loadAction(item);
						saveAction(item);
					}

					nodesProcessed++;
					UpdateProgress(worker, nodesProcessed, selectedNodeCount);
				}
			}
		}

		#endregion

		#region Sync

		private void btnSync_Click(object sender, EventArgs e)
		{
			bwSync.RunWorkerAsync();
		}

		private void bwSync_DoWork(object sender, DoWorkEventArgs e)
		{
			UpdateProgress(bwSync, 0, 0);

			var destinationService = _DestinationService;
			destinationService.BasePath = null;
			destinationService.SourceService = _SourceService;

			ProcessItems(rptSourceTree.Nodes, bwSync, _SourceService.LoadItem, _DestinationService.UploadItem);
			UpdateProgress(bwSync, 1, 1);
		}

		private void bwSync_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbSource.Value = e.ProgressPercentage;
			pbDest.Value = e.ProgressPercentage;
		}

		private void bwSync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			UpdateSelections(rptSourceTree.Nodes, false);
			LoadDestinationTree();
			MessageBox.Show("Sync completed successfully.", "Sync complete");
		}

		#endregion

		#region Sync Schedules

		private void btnSyncSchedules_Click(object sender, EventArgs e)
		{
			_SyncSchedulesWorker.RunWorkerAsync();
		}

		private void bwSyncSchedules_DoWork(object sender, DoWorkEventArgs e)
		{
			UpdateProgress(_SyncSchedulesWorker, 0, 0);

			var sourceService = _SourceService;
			sourceService.LoadSchedules();

			var destinationService = _DestinationService;
			destinationService.BasePath = null;
			destinationService.SourceService = sourceService;
			destinationService.LoadSchedules();

			var schedules = sourceService.GetSchedules();
			for (var index = 0; index < schedules.Length; index++)
			{
				var schedule = schedules[index];
				destinationService.AddSchedule(schedule);
				UpdateProgress(_SyncSchedulesWorker, index, schedules.Length);
			}

			UpdateProgress(_SyncSchedulesWorker, 1, 1);
		}

		private void bwSyncSchedules_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbSource.Value = e.ProgressPercentage;
			pbDest.Value = e.ProgressPercentage;
		}

		private void bwSyncSchedules_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			UpdateSelections(rptSourceTree.Nodes, false);
			LoadDestinationTree();
			MessageBox.Show("Schedule sync completed successfully.", "Schedule sync complete");
		}

		#endregion

		#region Download

		private void btnDownload_Click(object sender, EventArgs e)
		{
			bwDownload.RunWorkerAsync();
		}

		private void bwDownload_DoWork(object sender, DoWorkEventArgs e)
		{
			_DestinationService.BasePath = txtLocalPath.Text;

			UpdateProgress(bwDownload, 0, 0);
			ProcessItems(rptSourceTree.Nodes, bwDownload, _SourceService.LoadItem, _DestinationService.SaveItem);
			UpdateProgress(bwDownload, 1, 1);
		}

		private void bwDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbSource.Value = e.ProgressPercentage;
		}

		private void bwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			UpdateSelections(rptSourceTree.Nodes, false);
			MessageBox.Show("Report files downloaded successfully.", "Download complete");
		}

		#endregion

		#region Upload

		private void btnUpload_Click(object sender, EventArgs e)
		{
			existingPaths = new List<string>();
			if (String.IsNullOrEmpty(txtLocalPath.Text))
			{
				MessageBox.Show("Please select the folder to upload.");
				return;
			}
			bwUpload.RunWorkerAsync();
		}

		private void bwUpload_DoWork(object sender, DoWorkEventArgs e)
		{
			// Todo: Load from file system (Should load into tree view so they can select)
			// Todo: Format path (remove base path and extension)
			// Todo: Upload, re-use framework for Sync and download

			bwUpload.ReportProgress(100);
		}

		private void bwUpload_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbDest.Value = e.ProgressPercentage;
		}

		private void bwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			LoadDestinationTree();
			MessageBox.Show("Upload completed successfully.", "Upload complete");
		}

		#endregion

		#region Load Trees

		private void LoadSourceTree()
		{
			var service = _SourceService;
			service.ServiceUrl = txtSourceUrl.Text;
			service.Username = txtSourceUser.Text;
			service.Password = txtSourcePassword.Text;

			LoadTreeNodes(service, rptSourceTree);
		}

		private void LoadDestinationTree()
		{
			var service = _DestinationService;
			service.ServiceUrl = txtDestUrl.Text;
			service.Username = txtDestUser.Text;
			service.Password = txtDestPassword.Text;

			LoadTreeNodes(service, rptDestTree);
		}

		private void LoadTreeNodes(ServiceWrapper service, TreeView tree)
		{
			try
			{
				service.LoadReportItems();
				service.LoadSchedules();

				var nodes = tree.Nodes;
				nodes.Clear();

				LoadTreeNodes(nodes, service.RootItem);

				tree.AfterCheck -= OnNodeChecked;
				tree.AfterCheck += OnNodeChecked;
			}
			catch (Exception exception)
			{
				MessageBox.Show("Loading failed." + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LoadTreeNodes(TreeNodeCollection tree, ReportItem parent)
		{
			foreach (var child in parent.Children)
			{
				var parentNode = new TreeNode
					{
						Name = child.Name,
						Text = child.Name,
						Tag = child
					};
				tree.Add(parentNode);

				LoadTreeNodes(parentNode.Nodes, child);
			}
		}

		#endregion

		#region Cleanup

		private void btnDest_Click(object sender, EventArgs e)
		{
			DialogResult result = dlgDest.ShowDialog();
			if (result == DialogResult.OK)
			{
				txtLocalPath.Text = dlgDest.SelectedPath;
			}
		}

		private void rptDestTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			uploadPath = ROOT_FOLDER + e.Node.FullPath.Replace("\\", PATH_SEPERATOR);
		}

		private void ReportSync_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!chkSaveSource.Checked)
			{
				Settings.Default.SourcePassword = string.Empty;
			}
			
			if (!chkSaveDest.Checked)
			{
				Settings.Default.DestPassword = string.Empty;
			}

			Settings.Default.Save();
		}

		private void mapDataSourcesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Todo
			////var frmMapDS = new MapDatasources();
			////frmMapDS.sourceDS = sourceDS;
			////frmMapDS.destDS = destDS;
			////var result = frmMapDS.ShowDialog();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var res = dlgOpenFile.ShowDialog();
			if (res == DialogResult.OK)
			{
				var data = File.ReadAllLines(dlgOpenFile.FileName);
				int stage = 0;
				foreach (var line in data)
				{
					if (line == SOURCE_SELECTION_START)
					{
						stage = 1;
						continue;
					}
					else if (line == DEST_SELECTION_START)
					{
						stage = 2;
						continue;
					}
					else if (line == MAPPING_START)
					{
						stage = 3;
						continue;
					}
					switch (stage)
					{
						case 1:
							checkNodeIfPathExists(rptSourceTree.Nodes, line);
							break;
						case 2:
							checkNodeIfPathExists(rptDestTree.Nodes, line);
							break;
						case 3:
							var entryParts = line.Split('=');
							if (entryParts.Length == 2 && destDS.ContainsKey(entryParts[0]))
							{
								destDS[entryParts[0]] = entryParts[1];
							}
							break;
					}
				}
			}
		}

		private void checkNodeIfPathExists(TreeNodeCollection nodes, string path)
		{
			var parts = path.Split(new char[] { '\\' }, 2);
			var key = parts[0];
			if (nodes.ContainsKey(key))
			{
				if (parts.Length == 1)
				{
					nodes[key].Checked = true;
				}
				else
				{
					nodes[key].Expand();
					checkNodeIfPathExists(nodes[key].Nodes, parts[1]);
				}
			}
		}

		private string saveCheckedNodes(TreeNodeCollection nodes)
		{
			var data = "";
			foreach (TreeNode node in nodes)
			{
				if (node.Checked)
				{
					data += node.FullPath + Environment.NewLine;
				}
				data += saveCheckedNodes(node.Nodes);
			}
			return data;
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetPathAndSave();
		}

		private void SetPathAndSave()
		{
			var res = dlgSaveFile.ShowDialog();
			if (res == DialogResult.OK)
			{
				pathOnDisk = dlgSaveFile.FileName;
				SaveSelectedNodesToDisk();
			}
		}

		// Todo: This is overkill
		private void SaveSelectedNodesToDisk()
		{
			if (!String.IsNullOrEmpty(pathOnDisk))
			{
				string data = SOURCE_SELECTION_START + Environment.NewLine;
				data += saveCheckedNodes(rptSourceTree.Nodes);
				data += DEST_SELECTION_START + Environment.NewLine;
				data += saveCheckedNodes(rptDestTree.Nodes);
				data += MAPPING_START + Environment.NewLine;

				//save mapping
				foreach (var entry in destDS)
				{
					data += entry.Key + "=" + entry.Value + Environment.NewLine;
				}
				File.WriteAllText(pathOnDisk, data);
			}
			else
			{
				SetPathAndSave();
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveSelectedNodesToDisk();
		}

		#endregion
	}
}
