using LOT.BLL.Exceptions;
using LOT.BLL.Models;
using LOT.BLL.Models.Members;

namespace LOT.BLL.Services.Members
{
    internal class PositionService
    {
        /// <summary>
        /// Method, that will swich player main position between positions he already learned.
        /// </summary>
        /// <param name="positionName"></param>
        internal static void ChangeMainPosition(MemberModel member, PositionModel newMainPosition)
        {
            if (member.Positions.Count < 2)
                throw new PositionServicesException("Member hasn't enaught positions!");
            else if (member.Positions[1].Equals(newMainPosition))
                member.Positions.Reverse();
        }

        /// <summary>
        /// Method added
        /// </summary>
        /// <param name="member"></param>
        /// <param name="newPositionName"></param>
        /// <param name="user"></param>
        /// <exception cref="PositionServicesException"></exception>
        internal static void AddPosition(UserModel user, List<PositionModel> positions, string newPositionName)
        {
            if (positions.Count >= 2)
                throw new PositionServicesException("Member already know maximum positions he can!");
            else
            {
                foreach (PositionModel position in positions)
                {
                    if (position.Name == newPositionName)
                        throw new PositionServicesException("Error! This member is already can play this position!");
                }
                positions.Add(new PositionModel(user, newPositionName));
            }
        }
    }
}
