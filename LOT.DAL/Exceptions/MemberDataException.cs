namespace LOT.DAL.Exceptions
{
    internal class MemberDataException : Exception
    {
        public MemberDataException() : base() { }
        public MemberDataException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
