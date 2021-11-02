using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Mocking
{
    public class HousekeeperStatementReport : IHousekeeperStatementReport
    {

        public bool HasData { get; set; }
        public DateTime StatementDate { get; }

        public HousekeeperStatementReport(int housekeeperOid, DateTime statementDate)
        {
            StatementDate = statementDate;
        }

        public void CreateDocument()
        {
        }

        public void ExportToPdf(string filename)
        {
        }
    }
}
