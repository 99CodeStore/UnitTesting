using NUnit.Framework;
using Fundamentals.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Fundaementals.UnitTests.Mocking
{
    [TestFixture()]
    public class HouseKeeperServiceTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IStatementGenerator> stementGenerator;
        private Mock<IEmailSender> emailSender;
        private Mock<IXtraMessageBox> messageBox;

        private HouseKeeperService service;
        private HouseKeeper houseKeeper;
        DateTime _statementDate;

        private string statementFilename  ;

        [SetUp]
        public void SetUp()
        {
            houseKeeper = new HouseKeeper() { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };
            _statementDate = new DateTime(2021, 10, 1);
            statementFilename = "fileName";


            unitOfWork = new Mock<IUnitOfWork>();
            stementGenerator = new Mock<IStatementGenerator>();

            stementGenerator.Setup(sg => sg.SaveStatement(houseKeeper.Oid, houseKeeper.FullName, _statementDate))
            .Returns(()=>statementFilename);

            emailSender = new Mock<IEmailSender>();
            messageBox = new Mock<IXtraMessageBox>();


            unitOfWork.Setup(uow => uow.Query<HouseKeeper>()).Returns(new List<HouseKeeper>()
            {
                houseKeeper
            }.AsQueryable());

            service = new HouseKeeperService(
               unitOfWork.Object,
               stementGenerator.Object,
               emailSender.Object,
               messageBox.Object);
        }


        [Test()]
        public void SendStatementsEmail_WhenCalled_GenerateStatements()
        {
            service.SendStatementEmails(_statementDate);
            stementGenerator.Verify(sg => sg.SaveStatement(houseKeeper.Oid, houseKeeper.FullName, _statementDate));
        }

        [Test()]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementsEmail_HouseKeeperEmailIsNullEmptyOrWhiteSpace_NotGenerateStatements(string email)
        {
            houseKeeper.Email = email;

            service.SendStatementEmails(_statementDate);
            stementGenerator.Verify(sg => sg.SaveStatement(houseKeeper.Oid, houseKeeper.FullName, _statementDate), Times.Never);
        }

        [Test()]
        public void SendStatementsEmail_WhenCalled_SentStatementsInToMail()
        {

            service.SendStatementEmails(_statementDate);

            emailSender.Verify(sg => sg.EmailFile(
                houseKeeper.Email,
                houseKeeper.StatementEmailBody,
                statementFilename, It.IsAny<string>()));
        }
        
        [Test()]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementsEmail_StatementFileNameIsNullEmptyOrWhiteSpace_ShouldSentStatementsInToMail(string filename)
        {
            this.statementFilename = filename;

            service.SendStatementEmails(_statementDate);

            emailSender.Verify(sg => sg.EmailFile(
                houseKeeper.Email,
                houseKeeper.StatementEmailBody,
                statementFilename, It.IsAny<string>()),Times.Never);
        }
        [Test()]     
        public void SendStatementsEmail_EmailSendingFails_DisplayErrorMessageBox()
        {
            emailSender.Setup(es=>es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()

                )).Throws<Exception>();

            service.SendStatementEmails(_statementDate);

            messageBox.Verify(mb=>mb.Show(It.IsAny<string>(),It.IsAny<string>(),MessageBoxButtons.OK));

        }
    }
}