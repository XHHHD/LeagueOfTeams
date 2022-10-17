namespace LOT.BLL.Exceptions
{
    internal class MemberServicesException : Exception
    {
        public MemberServicesException() : base() { }
        public MemberServicesException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
