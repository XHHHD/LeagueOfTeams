namespace LOT.BLL.Models.Members
{
    public class PositionModel
    {
        private readonly int _id;
        private readonly string _name;
        private uint _expiriance;
        private double _favorite;
        private int _power;
        private int _defence;
        private int _health;
        readonly Random random = new();


        internal int Id { get => _id; }
        /// <summary>
        /// Name of position: top/mid/bot/damagedealer/defender or else.
        /// For more information look PositionList.
        /// </summary>
        internal string Name { get => _name; }

        /// <summary>
        /// Expiriance played or trained on this position.
        /// </summary>
        internal uint Expiriance { get => _expiriance; set => _expiriance = value; }

        /// <summary>
        /// Points score for implementatin skills of member.
        /// </summary>
        internal uint Level { get => _expiriance/1000; }

        /// <summary>
        /// Secondary argumet for the mental motivation users.
        /// </summary>
        internal byte Rank { get => (byte)_expiriance; }

        /// <summary>
        /// Core parameter for win position fight between members.
        /// </summary>
        internal int Power { get => _power; set => _power = value; }

        /// <summary>
        /// This will multiply position power member in fight.
        /// </summary>
        internal double Happines { get => _favorite; }

        /// <summary>
        /// Member chanse get resistance on corrent position.
        /// </summary>
        internal int Defence { get => _defence; }

        /// <summary>
        /// Current position health.
        /// </summary>
        internal int Health { get => _health; set => _health = value; }

        int MemberId { get; set; }
        MemberModel Member { get; set; }



        //This constructor is using,
        //when we will generate free recruits list.
        internal PositionModel(UserModel user, string name)
        {
            _name = name;
            //Equating member with player.
            _expiriance = (uint)((user.Level + (((double)random.Next(-10,5))/5))*1000);
            _favorite = Level + random.Next(-1,1);
            _power = (int)Level + random.Next(-1,1);
            _defence = (int)Level + random.Next(-1,1);
            _health = (int)Level + random.Next(-1,1);
        }

        internal void AddPositionExpiriance(uint addedExpirianceAmount)
        {
            uint positionLevelWas = Level;
            _expiriance += addedExpirianceAmount;
            if (Level > positionLevelWas) MemberPositionLevelUp();
        }
        private void MemberPositionLevelUp()
        {
            _expiriance++;
            _favorite++;
            _power++;
            _defence++;
            _health++;
        }
    }
}
