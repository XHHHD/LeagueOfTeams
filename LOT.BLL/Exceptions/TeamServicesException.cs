namespace LOT.BLL.Exceptions
{
    internal class TeamServicesException : Exception
    {
        public TeamServicesException() : base() { }
        public TeamServicesException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
