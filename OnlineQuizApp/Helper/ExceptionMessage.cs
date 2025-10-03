namespace OnlineQuizApp.Helper
{
    public class ExceptionMessage
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ExceptionMessage() { }

        public ExceptionMessage(int ErrorCode, string ErrorMessage)
        {
            this.ErrorCode = ErrorCode;
            this.ErrorMessage = ErrorMessage;
        }

    }
}
