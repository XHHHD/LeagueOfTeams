namespace LOT.DAL.Exceptions
{
    internal class UserDataException : Exception
    {
        public UserDataException() : base() { }
        public UserDataException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
