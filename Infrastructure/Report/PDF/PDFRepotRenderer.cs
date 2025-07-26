using Domain.Report.Abstractions;

namespace Infrastructure.Report.PDF
{
    //Abstract Factory
    public class PDFRepotRenderer : IReportRenderer
    {
        public void RenderReport(Domain.Report.Report report)
        {
            throw new NotImplementedException("RenderPdfReport");
        }
    }
}
