using Application.Report.Factories;
using Application.Report.Interfaces;

namespace Application.Report.Factories
{
    public interface IReportFactoryResolver
    {
         IReportFactory GetReportFactory(string reportType);
    }
}

