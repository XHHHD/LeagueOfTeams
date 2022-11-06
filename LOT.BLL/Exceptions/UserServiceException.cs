namespace LOT.BLL.Exceptions
{
    internal class UserServiceException : Exception
    {
        public UserServiceException() : base() { }
        public UserServiceException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
