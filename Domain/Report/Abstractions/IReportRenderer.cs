namespace Domain.Report.Abstractions
{
    //Abstract Factory
    public interface IReportRenderer
    {
        void RenderReport(Report report);
    }
}
