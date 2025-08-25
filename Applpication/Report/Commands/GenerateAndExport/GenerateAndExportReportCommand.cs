using Application.Report.Factories;
using Application.Report.Interfaces;
using Domain.Report;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace Application.Report.Commands.ReportAndExport
{
    public class GenerateAndExportReportCommand : IRequest
    {
        public string Title { get; set; }
    }
    internal class GenerateAndExportReportCommandHandler : IRequestHandler<GenerateAndExportReportCommand>
    {
        private readonly IReportFactoryResolver _factory;

        public GenerateAndExportReportCommandHandler(IReportFactoryResolver factory)
        {
            _factory = factory;
        }
        //Abstract Factory

        Task<Unit> IRequestHandler<GenerateAndExportReportCommand, Unit>.Handle(GenerateAndExportReportCommand request, CancellationToken cancellationToken)
        {
            var excelService = _factory.GetReportFactory("excEl");
            var pdfService = _factory.GetReportFactory("pdf");

            var excelGenerator = excelService.ReportGenerator();
            var excelRenderer = excelService.ReportRenderer();
            var excelExporter = excelService.ReportExporter();

            var pdfGenerator = pdfService.ReportGenerator();
            var pdfRenderer = pdfService.ReportRenderer();
            var pdfExporter = pdfService.ReportExporter();
            //try
            //{
            var excelReport = excelGenerator.GenerateReport(request.Title);
            excelRenderer.RenderReport(excelReport);
            excelExporter.ExporterReport(excelReport);

            var pdfReport = pdfGenerator.GenerateReport(request.Title);
            pdfRenderer.RenderReport(pdfReport);
            pdfExporter.ExporterReport(pdfReport);
            //}
            //catch (NotImplementedException ex)
            //{
            //    throw new NotImplementedException(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //return Task.CompletedTask;
            return Task.FromResult(Unit.Value);
        }
    }
}
