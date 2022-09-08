namespace LeagueOfTeamsDataAccess.Entities
{
    public class Positions
    {
        public int Id { get; set; }
        public int PositionsNamesId { get; set; }
        public uint Expiriance { get; set; }
        public uint Level { get; set; }
        public byte Rank { get; set; }
        public int Power { get; set; }
        public double Favorite { get; set; }
        public int Defence { get; set; }
        public int Health { get; set; }
    }
}
