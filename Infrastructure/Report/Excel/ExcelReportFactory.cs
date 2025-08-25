using Application.Report.Interfaces;
using Domain.Report.Abstractions;

namespace Infrastructure.Report.Excel
{
    //Abstract Factory
    public class ExcelReportFactory : IExcelReportFactory
    {
        public IReportExporter ReportExporter() => new ExcelRepotExporter();

        public IReportGenerator ReportGenerator() => new ExcelRepotGenerator();

        public IReportRenderer ReportRenderer() => new ExcelRepotRenderer();
    }
}
