namespace ReportSync
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Text;
	using ReportService;

	public class ServiceWrapper
	{
		private const string _Webservice = "/ReportService2005.asmx";

		private string _BasePath;
		private ReportingService2005 _Service;
		private string _ServiceUrl;
		private string _Username;
		private string _Password;

		public ServiceWrapper()
		{
			AllItems = new Dictionary<string, ReportItem>();
			DataSources = new Dictionary<string, string>();
			Schedules = new Dictionary<string, Schedule>();
		}

		#region Properties

		public string BasePath
		{
			get
			{
				return _BasePath;
			}
			set
			{
				if (value != _BasePath)
				{
					_BasePath = value;
					DisposeOfService();
				}
			}
		}

		public string ServiceUrl
		{
			get
			{
				return _ServiceUrl;
			}
			set
			{
				if (value != _ServiceUrl)
				{
					var serviceUrl = value;
					if (serviceUrl != null
						&& !serviceUrl.EndsWith(_Webservice, StringComparison.InvariantCultureIgnoreCase))
					{
						serviceUrl += _Webservice;
					}

					_ServiceUrl = serviceUrl;
					DisposeOfService();
				}
			}
		}

		public string Username
		{
			get
			{
				return _Username;
			}
			set
			{
				if (value != _Username)
				{
					_Username = value;
					DisposeOfService();
				}
			}
		}

		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				if (value != _Password)
				{
					_Password = value;
					DisposeOfService();
				}
			}
		}

		public ReportingService2005 Service
		{
			get
			{
				if (_Service == null)
				{
					var service = new ReportingService2005();
					service.Url = ServiceUrl;
					service.Credentials = BuildCredentials();

					_Service = service;
				}

				return _Service;
			}
		}

		public ReportItem RootItem { get; private set; }
		public Dictionary<string, ReportItem> AllItems { get; private set; }   
		public Dictionary<string, string> DataSources { get; private set; }
		public Dictionary<string, Schedule> Schedules { get; private set; } 
		public ServiceWrapper SourceService { get; set; }

		#endregion

		#region Setup

		public bool LoadReportItems()
		{
			AllItems.Clear();
			DataSources.Clear();

			var service = Service;
			var rootItem = new ReportItem
				{
					Name = "/",
					Path = "/",
					ItemType = ItemTypeEnum.Unknown
				};
			RootItem = rootItem;

			return LoadReportItems(service, rootItem);
		}
		
		private bool LoadReportItems(ReportingService2005 service, ReportItem parent)
		{
			var dataSources = DataSources;
			var newItems = GetReportItems(service, parent.Path);
			foreach (var item in newItems)
			{
				switch (item.Type)
				{
					case ItemTypeEnum.DataSource:
						if (!dataSources.ContainsKey(item.Name))
						{
							dataSources.Add(item.Name, item.Path);
						}
						break;
					case ItemTypeEnum.Folder:
						var newParent = AddReportItem(parent, item, true);
						LoadReportItems(service, newParent);
						break;
					case ItemTypeEnum.Model:
						break;
					default:
						AddReportItem(parent, item, false);
						break;
				}
			}

			return true;
		}

		private ReportItem AddReportItem(ReportItem parent, CatalogItem item, bool isDirectory)
		{
			var child = new ReportItem
				{
					Key = item.Path.ToLowerInvariant(),
					Name = item.Name,
					Path = item.Path,
					ParentPath = parent.Path,
					Item = item,
					ItemType = item.Type,
					Parent = parent
				};
			parent.Children.Add(child);

			AllItems.Add(child.Key, child);
			return child;
		}

		private CatalogItem[] GetReportItems(ReportingService2005 service, string path)
		{
			try
			{
				return service.ListChildren(path, false);
			}
			catch (Exception exception)
			{
				// Todo: Display error message
				return new CatalogItem[0];
			}
		}

		private NetworkCredential BuildCredentials()
		{
			var username = Username;
			var password = Password;
			if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
			{
				return null;
			}

			var usernameParts = username.Split('\\', '/');
			if (usernameParts.Length > 2)
			{
				throw new InvalidOperationException("Invalid username.");
			}
			
			if (usernameParts.Length == 2)
			{
				return new NetworkCredential(usernameParts[1], password, usernameParts[0]);
			}

			return new NetworkCredential(username, password);
		}

		private void DisposeOfService()
		{
			var service = _Service;
			if (service != null)
			{
				service.Dispose();
				_Service = null;
			}
		}

		#endregion

		#region Load

		public void LoadItem(ReportItem item)
		{
			switch (item.ItemType)
			{
				case ItemTypeEnum.Report:
				case ItemTypeEnum.LinkedReport:
					LoadReport(item);
					LoadSubscriptions(item);
					break;
				case ItemTypeEnum.Resource:
					LoadResource(item);
					break;
			}
		}

		private void LoadReport(ReportItem item)
		{
			item.ReportDefinition = _Service.GetReportDefinition(item.Path);
			item.DataSources = _Service.GetItemDataSources(item.Path);
		}

		private void LoadSubscriptions(ReportItem item)
		{
			var subscriptions = _Service.ListSubscriptions(item.Path, Username);
			foreach (var subscription in subscriptions)
			{
				ExtensionSettings extensionSettings;
				string description;
				ActiveState active;
				string status;
				string eventType;
				string matchData;
				ParameterValue[] values;
				var result = _Service.GetSubscriptionProperties(subscription.SubscriptionID, out extensionSettings, out description, out active, out status, out eventType, out matchData, out values);
				var subscriptionItem = new SubscriptionItem
					{
						ExtensionSettings = extensionSettings,
						Description = description,
						ActiveState = active,
						Status = status,
						EventType = eventType,
						MatchData = matchData,
						ParameterValues = values
					};
				item.Subscriptions.Add(subscriptionItem);

				var schedule = Schedules.Select(s => s.Value)
					.FirstOrDefault(s => s.ScheduleID == matchData);
				if (schedule != null)
				{
					subscriptionItem.ScheduleName = schedule.Name;
				}
			}
		}

		private void LoadResource(ReportItem item)
		{
			string resourceType;
			item.ResourceContents = _Service.GetResourceContents(item.Path, out resourceType);
			item.ResourceType = resourceType;
		}

		#endregion

		#region Upload

		public void UploadItem(ReportItem item)
		{
			switch (item.ItemType)
			{
				case ItemTypeEnum.Folder:
					UploadFolder(item);
					break;
				case ItemTypeEnum.Report:
				case ItemTypeEnum.LinkedReport:
					UploadReport(item);
					UploadSubscriptions(item);
					break;
				case ItemTypeEnum.Resource:
					UploadResource(item);
					break;
				case ItemTypeEnum.DataSource:
					UploadDataSource(item);
					break;
			}
		}

		private void UploadFolder(ReportItem item)
		{
			var exists = HasItem(item);
			if (exists)
			{
				return;
			}

			var parent = item.Parent;
			var parentPath = parent != null ? parent.Path : "/";
			_Service.CreateFolder(item.Name, parentPath, null);
		}

		private void UploadDataSource(ReportItem item)
		{
			// Todo
			////_Service.CreateDataSource(item.Name, item.ParentPath, true, );
		}

		private void UploadReport(ReportItem item)
		{
			_Service.CreateReport(item.Name, item.ParentPath, true, item.ReportDefinition, null);

			var dataSources = GetDataSources(item.DataSources);
			if (dataSources.Length > 0)
			{
				_Service.SetItemDataSources(item.Path, dataSources);
			}
		}

		private void UploadResource(ReportItem item)
		{
			_Service.CreateResource(item.Name, item.ParentPath, true, item.ResourceContents, item.ResourceType, null);
		}

		private void UploadDataSources(ReportItem item)
		{
			// Todo
		}

		private void UploadSubscriptions(ReportItem item)
		{
			foreach (var subscription in item.Subscriptions)
			{
				UploadSubscription(item, subscription);
			}
		}

		private void UploadSubscription(ReportItem item, SubscriptionItem subscription)
		{
			try
			{
				var schedule = Schedules.Select(s => s.Value)
					.FirstOrDefault(s => String.Equals(s.Name, subscription.ScheduleName, StringComparison.InvariantCultureIgnoreCase));
				if (schedule == null)
				{
					return;
				}

				_Service.CreateSubscription(item.Path, subscription.ExtensionSettings, subscription.Description,
					subscription.EventType, schedule.ScheduleID, subscription.ParameterValues);
			}
			catch (Exception)
			{
				// Suppress
			}
		}

		public bool HasItem(ReportItem item)
		{
			return AllItems.ContainsKey(item.Key);
		}

		private DataSource[] GetDataSources(DataSource[] oldDataSources)
		{
			var dataSources = DataSources;
			var results = new List<DataSource>();
			if (oldDataSources != null)
			{
				foreach (var oldDataSource in oldDataSources)
				{
					if (dataSources.ContainsKey(oldDataSource.Name))
					{
						var reference = new DataSourceReference
							{
								Reference = dataSources[oldDataSource.Name]
							};
						var newDataSource = new DataSource
							{
								Name = oldDataSource.Name,
								Item = reference
							};
						results.Add(newDataSource);
					}
				}
			}

			return results.ToArray();
		}

		#endregion

		#region Save

		public void SaveItem(ReportItem item)
		{
			switch (item.ItemType)
			{
				case ItemTypeEnum.Folder:
					SaveFolder(item);
					break;
				case ItemTypeEnum.Report:
				case ItemTypeEnum.LinkedReport:
					SaveReport(item);
					SaveSubscriptions(item);
					break;
				case ItemTypeEnum.Resource:
					SaveResource(item);
					break;
				case ItemTypeEnum.DataSource:
					SaveDataSource(item);
					break;
			}
		}

		private void SaveFolder(ReportItem item)
		{
			var path = GetItemPath(item);
			if (string.IsNullOrEmpty(path))
			{
				return;
			}

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}

		private void SaveReport(ReportItem item)
		{
			var path = GetItemPath(item, ".rdl");
			if (string.IsNullOrEmpty(path))
			{
				return;
			}

			if (File.Exists(path))
			{
				File.Delete(path);
			}

			var content = Encoding.UTF8.GetString(item.ReportDefinition);

			using (var file = File.CreateText(path))
			{
				file.Write(content);
				file.Flush();
				file.Close();
			}
		}

		private void SaveSubscriptions(ReportItem item)
		{
			// Todo
		}

		private void SaveResource(ReportItem item)
		{
			// Todo
		}

		private void SaveDataSource(ReportItem item)
		{
			// Todo
		}

		private string GetItemPath(ReportItem item, string extension = null)
		{
			var basePath = BasePath;
			if (String.IsNullOrEmpty(basePath))
			{
				return string.Empty;
			}

			return String.Concat(BasePath, item.Path, extension);
		}

		#endregion

		#region Schedules

		public void LoadSchedules()
		{
			var allSchedules = Schedules;
			allSchedules.Clear();

			var schedules = _Service.ListSchedules();
			foreach (var schedule in schedules)
			{
				allSchedules.Add(schedule.Name, schedule);
			}
		}

		public Schedule[] GetSchedules()
		{
			return _Service.ListSchedules();
		}

		public void AddSchedule(Schedule schedule)
		{
			if (Schedules.ContainsKey(schedule.Name))
			{
				return;
			}

			_Service.CreateSchedule(schedule.Name, schedule.Definition);
		}

		#endregion
	}
}
