namespace Domain.Report.Abstractions
{
    //Abstract Factory
    public interface IReportGenerator
    {
        Report GenerateReport(string title);
    }
}
