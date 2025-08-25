using Application.Report.Interfaces;
using Domain.Report.Abstractions;

namespace Infrastructure.Report.PDF
{
    //Abstract Factory
    public class PDFReportFactory : IPdfReportFactory
    {
        public IReportExporter ReportExporter() => new PDFRepotExporter();

        public IReportGenerator ReportGenerator() => new PDFRepotGenerator();

        public IReportRenderer ReportRenderer() => new PDFRepotRenderer();
    }
}