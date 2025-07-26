using Domain.Report.Abstractions;

namespace Infrastructure.Report.Excel
{
    //Abstract Factory
    public class ExcelRepotExporter : IReportExporter
    {
        public void ExporterReport(Domain.Report.Report report)
        {
            throw new NotImplementedException("ExportExcelReport");
        }
    }
}
