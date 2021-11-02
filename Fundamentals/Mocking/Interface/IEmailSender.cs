namespace Fundamentals.Mocking
{
    public interface IEmailSender
    {
        void EmailFile(string emailAddress, string emailBody, string statementFilename, string v);
    }
}