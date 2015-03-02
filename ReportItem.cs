namespace ReportSync
{
	using System.Collections.Generic;
	using ReportService;

	public class ReportItem
	{
		public ReportItem()
		{
			Children = new List<ReportItem>();
			Subscriptions = new List<SubscriptionItem>();
		}

		public string Key { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public string ParentPath { get; set; }
		public ItemTypeEnum ItemType { get; set; }
		public CatalogItem Item { get; set; }

		public string ResourceType { get; set; }
		public byte[] ResourceContents { get; set; }

		public byte[] ReportDefinition { get; set; }
		public List<SubscriptionItem> Subscriptions { get; set; } 
		public DataSource[] DataSources { get; set; }

		public bool IsDirectory
		{
			get
			{
				return ItemType == ItemTypeEnum.Folder;
			}
		}

		public bool IsResource
		{
			get
			{
				return ItemType == ItemTypeEnum.Resource;
			}
		}

		public bool IsReport
		{
			get
			{
				return ItemType == ItemTypeEnum.Report
					|| ItemType == ItemTypeEnum.LinkedReport;
			}
		}

		public ReportItem Parent { get; set; }
		public List<ReportItem> Children { get; private set; }
	}
}
