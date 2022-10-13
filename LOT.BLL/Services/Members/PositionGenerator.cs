using LOT.BLL.Enums;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Positions;
using System.Linq;

namespace LOT.BLL.Services.Members
{
    public static class PositionGenerator
    {
        private static Random random = new();
        private static PositionService service = new();
        public static PositionModel GeneratePosition(MemberModel member)
        {
            if (member.Positions.Count >= 2)
                throw new PositionServicesException("Member already know maximum positions he can!");
            else
            {
                foreach (PositionModel existingPosition in member.Positions)
                {
                    if (existingPosition.Name == newPositionName)
                        throw new PositionServicesException("Error! This member is already can play this position!");
                }

                member.Positions.Add(newPosition);
            }
        }

        private static PositionModel CreatePosition(int memberLevel = 1)
        {
            PositionModel position = CreateEmptyPosition(memberLevel);
            position.Name = GetNewRandomPositionName();
            service.Add(position);
            return service.Get(position);
        }

        /// <summary>
        /// Method create new empty position object without Name and Id.
        /// </summary>
        /// <returns>Empty PositionModel object.</returns>
        private static PositionModel CreateEmptyPosition(int memberLevel = 1)
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
        private static PositionsNames GetNewRandomPositionName()
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
        private static PositionsNames GetNewRandomPositionName(PositionsNames exceptedPosition)
        {
            Array names = Enum.GetValues(typeof(PositionsNames));
            
            names = names.Where(x => x != exceptedPosition)
                         .ToArray();
            PositionsNames newName = (PositionsNames)names
                        .GetValue(random.Next(names.Length));
            return newName;
        }
    }
}
