namespace LOT.DAL.Exceptions
{
    public class PositionDataException : Exception
    {
        public PositionDataException() : base() { }
        public PositionDataException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
