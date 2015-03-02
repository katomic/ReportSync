namespace ReportSync
{
	using ReportService;

	public class SubscriptionItem
	{
		public ExtensionSettings ExtensionSettings { get; set; }
		public string Description { get; set; }
		public ActiveState ActiveState { get; set; }
		public string Status { get; set; }
		public string EventType { get; set; }
		public string MatchData { get; set; }
		public ParameterValue[] ParameterValues { get; set; }
		
		public string ScheduleName { get; set; }
	}
}
