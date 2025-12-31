namespace SalesWebMvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(String Message) : base(Message)
        {
        }
    }
}
