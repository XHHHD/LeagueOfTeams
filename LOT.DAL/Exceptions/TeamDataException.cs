namespace LOT.DAL.Exceptions
{
    internal class TeamDataException : Exception
    {
        public TeamDataException() : base() { }
        public TeamDataException(string exeptionMessage) : base(exeptionMessage) { }
    }
}
