﻿using Domain.Report.Abstractions;
namespace Infrastructure.Report.Excel
{
    //Abstract Factory
    public class ExcelRepotGenerator : IReportGenerator
    {
        public Domain.Report.Report GenerateReport(string title)
        {
            throw new NotImplementedException("GenerateExcelReport");
        }
    }
}
