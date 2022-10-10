using LOT.BLL.Models.Teams;

namespace LOT.BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public uint Expiriance { get; set; }
        public uint Level { get => Expiriance / 1000; set => Expiriance = value * 1000; }
        public TeamModel? Team { get; set; }
    }
}
