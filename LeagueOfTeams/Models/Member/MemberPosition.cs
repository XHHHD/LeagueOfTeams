using System;

namespace LeagueOfTeamsModel.Models.Member
{
    internal class MemberPosition
    {
        readonly Random random = new();
        private readonly string _positionName;
        private uint _positionExpiriance;
        private double _positionFavorite;
        private int _positionPower;
        private int _positionDefence;
        private int _positionHealth;

        //Name of position: top/mid/bot/damagedealer/defender or else.
        //For more information look PositionList.
        internal string PositionName { get => _positionName; }

        //Expiriance played or trained on this position.
        internal uint PositionExpiriance { get => _positionExpiriance; set => _positionExpiriance = value; }

        //Points score for implementatin skills of member.
        internal uint PositionLevel { get => _positionExpiriance/1000; }

        //Secondary argumet for the mental motivation humans.
        internal byte PositionRank { get => (byte)_positionExpiriance; }

        //Core parameter for win position fight between members.
        internal int PositionPower { get => _positionPower; set => _positionPower = value; }

        //This will multiply position power member in fight.
        internal double PositionFavorite { get => _positionFavorite; }

        //Member chanse get resistance on corrent position.
        internal int PositionDefence { get => _positionDefence; }

        //Current position health
        internal int PositionHealth { get => _positionHealth; set => _positionHealth = value; }



        //This constructor is using,
        //when we will generate free recruits list.
        internal MemberPosition(uint playerLevel)
        {
            //Chise member position.
            _positionName = PositionsList.Positions[random.Next(0, 4)];
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
        internal MemberPosition(byte positionID, uint playerLevel) : this(playerLevel)
        {
            _positionName = PositionsList.Positions[positionID];
        }
        internal MemberPosition(string excludedPositionID, uint playerLevel, bool generateMemberWhithotThisPosition) : this(playerLevel)
        {
            do
            {
                _positionName = PositionsList.Positions[random.Next(0, 4)];
                if (_positionName != excludedPositionID) generateMemberWhithotThisPosition = false;
            } while (generateMemberWhithotThisPosition);
        }

        internal void AddPositionExpiriance(uint addedExpirianceAmount)
        {
            uint positionLevelWas = PositionLevel;
            _positionExpiriance += addedExpirianceAmount;
            if (PositionLevel != positionLevelWas) MemberPositionLevelUp();
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
