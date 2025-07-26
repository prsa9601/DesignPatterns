namespace Domain.Report
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime GenerateDate { get; set; }
        public string Title { get; set; }

        public ReportType reportType { get; set; }
        public Report()
        {
            
        }
    }
    public enum ReportType 
    {
        Excel,
        PDF,
        etc
    }
}
