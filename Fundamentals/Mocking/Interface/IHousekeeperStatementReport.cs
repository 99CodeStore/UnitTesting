using System;

namespace Fundamentals.Mocking
{
    public interface IHousekeeperStatementReport
    {
        bool HasData { get; set; }
        DateTime StatementDate { get; }

        void CreateDocument();
        void ExportToPdf(string filename);
    }
}