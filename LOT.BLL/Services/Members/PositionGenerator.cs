using LOT.BLL.Enums;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Positions;

namespace LOT.BLL.Services.Members
{
    public class PositionGenerator
    {
        private const int memberMaxPositionCountConst = 2;
        private const int powerUpperRandom = 10;
        private const int powerLowerRandomConst = -10;
        private const int happynesUpperRandom = 1;
        private const int happynesLowerRandom = -1;
        private const int defenceUpperRandom = 5;
        private const int defenceLowerRandom = 0;
        private const int healthUpperRandomConst = 110;
        private const int healthLowerRandomConst = 90;
        private Random random;
        private PositionService service;

        public PositionGenerator()
        {
            random = new();
            service = new();
        }

        /// <summary>
        /// A method that checks whether the conditions for adding random position or positions to the member model.
        /// It also includes submethods that create, fill and connect a new position.
        /// </summary>
        /// <param name="member">MemberMode.</param>
        /// <exception cref="PositionServicesException"></exception>
        public void GenerateNewPositionForMember(MemberModel member, PositionsNames expectedPosition, byte expectedPositionCount)
        {
            if (member.Positions.Count >= memberMaxPositionCountConst)
                throw new PositionServicesException("Member already know maximum positions he can!");
            else
            {
                if (member.Positions.Count == 0)
                {
                    member.Positions.Add(
                        CreatePositionInMember(member, expectedPosition));
                }
                if (member.Positions.Count < (int)expectedPositionCount)
                {
                    var randomPositionName = GetNewRandomPositionName();
                    member.Positions.Add(
                        CreatePositionInMember(member, randomPositionName));
                }
            }
        }

        /// <summary>
        /// Method fills the empty position, add it to the member model and save it in database.
        /// </summary>
        /// <param name="member">MemberModel.</param>
        /// <returns>Ready to use PositionModel.</returns>
        public PositionModel CreatePositionInMember(MemberModel member, PositionsNames positionName)
        {
            PositionModel position = CreateEmptyPosition((int)member.Level);
            position.Name = positionName;
            position.Member = member;
            service.Add(position);
            return position;
        }

        /// <summary>
        /// Method create new empty position object without Name and Id.
        /// </summary>
        /// <returns>Empty PositionModel object.</returns>
        private PositionModel CreateEmptyPosition(int memberLevel = 1)
        {
            var position = new PositionModel()
            {
                Expiriance = 0,
                Rank = 0,
                Power = memberLevel + random.Next(powerLowerRandomConst, powerUpperRandom),
                Happines = memberLevel + random.Next(happynesLowerRandom, happynesUpperRandom),
                Defence = memberLevel + random.Next(defenceLowerRandom, defenceUpperRandom),
                Health = memberLevel * 10 + random.Next(healthLowerRandomConst, healthUpperRandomConst)
            };

            if(position.Power < 0)
                position.Power = 0;

            return position;
        }

        /// <summary>
        /// Method generate random name for new position for member.
        /// </summary>
        /// <returns>Random PositionName enum.</returns>
        internal PositionsNames GetNewRandomPositionName()
        {
            Array names = Enum.GetValues(typeof(PositionsNames));

            PositionsNames newName = (PositionsNames)names.GetValue(random.Next(names.Length));

            return newName;
        }

        /// <summary>
        /// Method generate random name for new position for member, who alreday can play other position.
        /// Method is ramdomizing position name, except currently position.
        /// </summary>
        /// <param name="exceptedPosition">A position that the member already knows.</param>
        /// <returns>Random PositionName enum.</returns>
        public PositionsNames GetNewRandomPositionName(PositionsNames exceptedPosition)
        {
            List<PositionsNames> positionNames = Enum.GetValues(typeof(PositionsNames)).Cast<PositionsNames>().ToList();
            
            var filteredPositionNames = positionNames.Where(x => x != exceptedPosition);

            PositionsNames newName = positionNames[random.Next(positionNames.Count)];
            return newName;
        }
    }
}
