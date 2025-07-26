using Domain.Report.Abstractions;

namespace Infrastructure.Report.PDF
{
    //Abstract Factory
    public class PDFRepotGenerator : IReportGenerator
    {
        public Domain.Report.Report GenerateReport(string title)
        {
            throw new NotImplementedException("GeneratePdfReport");
        }
    }
}
