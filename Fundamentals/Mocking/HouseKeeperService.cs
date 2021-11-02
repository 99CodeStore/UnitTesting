using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Mocking
{
 
    public class HouseKeeperService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatementGenerator _statementGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IXtraMessageBox _xtraMessageBox;

        public HouseKeeperService(
            IUnitOfWork unitOfWork,
            IStatementGenerator statementGenerator,
            IEmailSender emailSender,
            IXtraMessageBox xtraMessageBox
            )
        {
            this._unitOfWork = unitOfWork;
            this._statementGenerator = statementGenerator;
            this._emailSender = emailSender;
            this._xtraMessageBox = xtraMessageBox;
        }

        public void SendStatementEmails(DateTime statementDate)
        {
            var houseKeepers = _unitOfWork.Query<HouseKeeper>();

            foreach (var houseKeeper in houseKeepers)
            {
                if (string.IsNullOrEmpty(houseKeeper.Email)|| string.IsNullOrWhiteSpace(houseKeeper.Email))
                    continue;

                var statementFilename = _statementGenerator.SaveStatement(houseKeeper.Oid, houseKeeper.FullName, statementDate);

                if (string.IsNullOrEmpty(statementFilename) || string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = houseKeeper.Email;
                var emailBody = houseKeeper.StatementEmailBody;

                try
                {
                    _emailSender.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpipper Statement {0:yyyy-MM} {1}", statementDate, houseKeeper.FullName)
                        );
                }
                catch (Exception e)
                {
                    _xtraMessageBox.Show(e.Message, string.Format("Email failure : {0}", emailAddress), MessageBoxButtons.OK);
                }
            }

        }

    }
}
