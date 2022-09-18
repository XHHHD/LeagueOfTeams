namespace LeagueOfTeamsBusinessLogic.Models.Members
{
    internal class MemberPosition
    {
        private readonly int _id;
        private readonly string _positionName;
        private uint _positionExpiriance;
        private double _positionFavorite;
        private int _positionPower;
        private int _positionDefence;
        private int _positionHealth;
        readonly Random random = new();


        internal int Id { get => _id; }
        /// <summary>
        /// Name of position: top/mid/bot/damagedealer/defender or else.
        /// For more information look PositionList.
        /// </summary>
        internal string PositionName { get => _positionName; }

        /// <summary>
        /// Expiriance played or trained on this position.
        /// </summary>
        internal uint PositionExpiriance { get => _positionExpiriance; set => _positionExpiriance = value; }

        /// <summary>
        /// Points score for implementatin skills of member.
        /// </summary>
        internal uint PositionLevel { get => _positionExpiriance/1000; }

        /// <summary>
        /// Secondary argumet for the mental motivation users.
        /// </summary>
        internal byte PositionRank { get => (byte)_positionExpiriance; }

        /// <summary>
        /// Core parameter for win position fight between members.
        /// </summary>
        internal int PositionPower { get => _positionPower; set => _positionPower = value; }

        /// <summary>
        /// This will multiply position power member in fight.
        /// </summary>
        internal double PositionHappines { get => _positionFavorite; }

        /// <summary>
        /// Member chanse get resistance on corrent position.
        /// </summary>
        internal int PositionDefence { get => _positionDefence; }

        /// <summary>
        /// Current position health.
        /// </summary>
        internal int PositionHealth { get => _positionHealth; set => _positionHealth = value; }



        //This constructor is using,
        //when we will generate free recruits list.
        internal MemberPosition(uint playerLevel)
        {
            //Chise member position.
            _positionName = PositionsList.Positions[random.Next(0, PositionsList.Positions.Count - 1)];
            //Equating member with player.
            _positionExpiriance = (uint)((playerLevel + (((double)random.Next(-10,5))/5))*1000);
            _positionFavorite = PositionLevel + random.Next(-1,1);
            _positionPower = (int)PositionLevel + random.Next(-1,1);
            _positionDefence = (int)PositionLevel + random.Next(-1,1);
            _positionHealth = (int)PositionLevel + random.Next(-1,1);
        }

        //This constructor will use,
        //when we generate member with corrent position or
        //secondary position for member.
        internal MemberPosition(string addPositionName, uint playerLevel) : this(playerLevel)
        {
            foreach ( string position in PositionsList.Positions)
            {
                if (position == addPositionName)
                {
                    _positionName = position;
                    break;
                }
            }
        }

        /// <summary>
        /// This constructor is for making secondary position.
        /// </summary>
        /// <param name="excludedPositionName">Name of first position. It will be used to avoid repetition.</param>
        /// <param name="playerLevel"></param>
        /// <param name="generateMemberWhithotThisPosition">Must be TRUE, for using this constructor.</param>
        internal MemberPosition(string excludedPositionName, uint playerLevel, bool generateMemberWhithotThisPosition) : this(playerLevel)
        {
            do
            {
                _positionName = PositionsList.Positions[random.Next(0, PositionsList.Positions.Count - 1)];
                if (_positionName != excludedPositionName) generateMemberWhithotThisPosition = false;
            } while (generateMemberWhithotThisPosition);
        }

        internal void AddPositionExpiriance(uint addedExpirianceAmount)
        {
            uint positionLevelWas = PositionLevel;
            _positionExpiriance += addedExpirianceAmount;
            if (PositionLevel > positionLevelWas) MemberPositionLevelUp();
        }
        private void MemberPositionLevelUp()
        {
            _positionExpiriance++;
            _positionFavorite++;
            _positionPower++;
            _positionDefence++;
            _positionHealth++;
        }
    }
}
