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
        private readonly IReportFactory _factory;

        public GenerateAndExportReportCommandHandler(IReportFactory factory)
        {
            _factory = factory;
        }
        //Abstract Factory

        Task<Unit> IRequestHandler<GenerateAndExportReportCommand, Unit>.Handle(GenerateAndExportReportCommand request, CancellationToken cancellationToken)
        {
            var generator = _factory.ReportGenerator();
            var renderer = _factory.ReportRenderer();
            var exporter = _factory.ReportExporter();
            try
            {
                var report = generator.GenerateReport(request.Title);
                renderer.RenderReport(report);
                exporter.ExporterReport(report);
            }
            catch (NotImplementedException ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return Task.CompletedTask;
            return null;
        }
    }
}
