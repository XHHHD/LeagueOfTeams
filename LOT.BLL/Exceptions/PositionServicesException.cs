namespace LOT.BLL.Exceptions
{
    internal class PositionServicesException : Exception
    {
        public PositionServicesException() : base() { }
        public PositionServicesException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
