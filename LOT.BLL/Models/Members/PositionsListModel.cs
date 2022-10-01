namespace LOT.BLL.Models.Members
{
    internal class PositionsListModel
    {
        /// <summary>
        /// List of the position. If will be some problems with privacy - this position can be changed.
        /// </summary>
        public static readonly List<string> Positions = new List<string>()
        {
            "Top",
            "Jungler",
            "Mid",
            "Bot",
            "Support"
        };
    }
}
