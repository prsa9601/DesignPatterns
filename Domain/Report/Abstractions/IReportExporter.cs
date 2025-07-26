namespace Domain.Report.Abstractions
{
    //Abstract Factory
    public interface IReportExporter
    {
        void ExporterReport(Report report);
    }
}
