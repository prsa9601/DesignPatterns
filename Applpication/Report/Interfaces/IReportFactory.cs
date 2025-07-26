using Domain.Report.Abstractions;

namespace Application.Report.Interfaces
{
    //Abstract Factory
    public interface IReportFactory
    {
        IReportGenerator ReportGenerator();
        IReportRenderer ReportRenderer();
        IReportExporter ReportExporter();
    }
}
