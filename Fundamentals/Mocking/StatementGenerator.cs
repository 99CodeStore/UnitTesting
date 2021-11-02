using System;
using System.IO;

namespace Fundamentals.Mocking
{
    public class StatementGenerator : IStatementGenerator
    {
        public string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate)
        {
            var report = new HousekeeperStatementReport(housekeeperOid, statementDate);
            if (report == null)
                return string.Empty;
            report.CreateDocument();

            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), string.Format("Sandpiper statement {0:yyyy-MM} {1}.pdf", statementDate, housekeeperName));
            report.ExportToPdf(fileName);
            return fileName;
        }
    }
}
