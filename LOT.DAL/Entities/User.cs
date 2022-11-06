namespace LOT.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public uint Expiriance { get; set; }
        public Team Team { get; set; }
    }
}
