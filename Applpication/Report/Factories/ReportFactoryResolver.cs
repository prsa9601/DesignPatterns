using Application.Report.Interfaces;

namespace Application.Report.Factories;

public class ReportFactoryResolver : IReportFactoryResolver
{
    private readonly IEnumerable<IReportFactory> _factories;

    public ReportFactoryResolver(IEnumerable<IReportFactory> factories)
    {
        _factories = factories;
    }

    public IReportFactory GetReportFactory(string reportType)
    {
        return reportType.ToUpper() switch{
            "PDF" => _factories.OfType<IPdfReportFactory>().First(),
            "EXCEL" => _factories.OfType<IExcelReportFactory>().First(),
            _ => throw new InvalidOperationException($"No factory found for report type: {reportType}")
        };
    }
}

