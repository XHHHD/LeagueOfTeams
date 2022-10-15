using LOT.BLL.Enums;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Positions;

namespace LOT.BLL.Services.Members
{
    public class PositionGenerator
    {
        private Random random = new();
        private PositionService service = new();
        //public static PositionModel GeneratePosition(MemberModel member)
        //{
        //    if (member.Positions.Count >= 2)
        //        throw new PositionServicesException("Member already know maximum positions he can!");
        //    else
        //    {
        //        foreach (PositionModel existingPosition in member.Positions)
        //        {
        //            if (existingPosition.Name == newPositionName)
        //                throw new PositionServicesException("Error! This member is already can play this position!");
        //        }

        //        member.Positions.Add(newPosition);
        //    }
        //}

        private PositionModel CreatePosition(int memberLevel = 1)
        {
            PositionModel position = CreateEmptyPosition(memberLevel);
            position.Name = GetNewRandomPositionName();
            // No need to adding postition in DB, before assigning position to player
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
                Power = memberLevel + random.Next(-10, 10),
                Happines = memberLevel + random.Next(-1, 1),
                Defence = memberLevel + random.Next(0, 5),
                Health = memberLevel * 10 + random.Next(-90, 110)
            };

            return position;
        }

        /// <summary>
        /// Method generate random name for new position for member.
        /// </summary>
        /// <returns>Random PositionName enum.</returns>
        private PositionsNames GetNewRandomPositionName()
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
