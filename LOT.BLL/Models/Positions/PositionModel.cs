using LOT.BLL.Enums;
using LOT.BLL.Models.Members;
using PositionsNames = LOT.BLL.Enums.PositionsNames;

namespace LOT.BLL.Models.Positions
{
    public class PositionModel
    {
        private int _id;
        private PositionsNames _name;
        private uint _expiriance;
        private double _favorite;
        private int _power;
        private int _defence;
        private int _health;
        private readonly Random random = new();


        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// Name of position: top/mid/bot/damagedealer/defender or else.
        /// For more information look PositionList.
        /// </summary>
        public PositionsNames Name { get => _name; set => _name = value; }

        /// <summary>
        /// Expirience played or trained on this position.
        /// </summary>
        public uint Expirience { get => _expiriance % 1000; set => _expiriance = value; }

        /// <summary>
        /// Points score for implementatin skills of member.
        /// </summary>
        public uint Level { get => _expiriance / 1000 + 1; }

        /// <summary>
        /// Secondary argumet for the mental motivation users.
        /// </summary>
        public byte Rank { get; set; }

        /// <summary>
        /// Core parameter for win position fight between members.
        /// </summary>
        public int Power { get => _power; set => _power = value; }

        /// <summary>
        /// This will multiply position power member in fight.
        /// </summary>
        public double Happines { get => _favorite; set => _favorite = value; }

        /// <summary>
        /// Member chanse get resistance on corrent position.
        /// </summary>
        public int Defence { get => _defence; set => _defence = value; }

        /// <summary>
        /// Current position maximum health.
        /// </summary>
        public int Health { get => _health; set => _health = value; }

        public int? MemberId { get; set; }
        public MemberModel? Member { get; set; }



        public PositionModel() { }
        //This constructor is using,
        //when we will generate free recruits list.
        public PositionModel(UserModel user, PositionsNames name)
        {
            _name = name;
            //Equating member with player.
            _expiriance = (uint)((user.Level + (double)random.Next(-10, 5) / 5) * 1000);
            _favorite = Level + random.Next(-1, 1);
            _power = (int)Level + random.Next(-1, 1);
            _defence = (int)Level + random.Next(-1, 1);
            _health = (int)Level + random.Next(-1, 1);
        }

        public void AddPositionExpiriance(uint addedExpirianceAmount)
        {
            uint positionLevelWas = Level;
            _expiriance += addedExpirianceAmount;
            if (Level > positionLevelWas)
                MemberPositionLevelUp();
        }
        private void MemberPositionLevelUp()
        {
            _favorite++;
            _power++;
            _defence++;
            _health++;
        }
        public void AddStats(StatsUp stat)
        {
            switch (stat)
            {
                case StatsUp.PositionFavorite:
                    {
                        _favorite++;
                        break;
                    }
                case StatsUp.PositionPower:
                    {
                        _power++;
                        break;
                    }
                case StatsUp.PositionDefence:
                    {
                        _defence++;
                        break;
                    }
                case StatsUp.PositionHealth:
                    {
                        _health++;
                        break;
                    }
            }
        }
    }
}
