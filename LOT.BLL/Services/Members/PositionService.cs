using AutoMapper;
using LOT.BLL.Enums;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Positions;
using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Members
{
    public class PositionService
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

        private readonly Random random;
        private readonly IMapper mapper;
        private readonly PositionRepository repository;

        public PositionService()
        {
            random = new();
            repository = new();
            mapper = MappingHelper.GetMapper();
        }

        /// <summary>
        /// Add new position in database.
        /// </summary>
        /// <param name="model">Position model.</param>
        /// <exception cref="PositionServicesException"></exception>
        public void Add(PositionModel model)
        {
            if (model is null)
                throw new PositionServicesException(nameof(model) + "is NULL!");
            else
                repository.AddPosition(mapper.Map<Position>(model));
        }

        /// <summary>
        /// Get position model from database by their ID.
        /// </summary>
        /// <param name="id">Position ID.</param>
        /// <returns>Position model.</returns>
        public PositionModel Get(int id)
        {
            var position = repository.GetPositionById(id);
            if (position is null)
                throw new PositionServicesException("Didnt find currently position in database!");
            else
                return mapper.Map<PositionModel>(position);
        }

        /// <summary>
        /// Remove position from databse by ID.
        /// </summary>
        /// <param name="id">Position ID.</param>
        /// <exception cref="PositionServicesException"></exception>
        public void Remove(int id)
        {
            var position = repository.GetPositionById(id);
            if (position is null)
                throw new PositionServicesException("Didnt find in database position for removing!");
            else
                repository.RemovePosition(position);
        }

        /// <summary>
        /// Remove position from databse.
        /// </summary>
        /// <param name="model">Position model.</param>
        /// <exception cref="PositionServicesException"></exception>
        public void Remove(PositionModel model)
        {
            if (model is null)
                throw new PositionServicesException("Model is NULL!");
            else
                Remove(model.Id);
        }

        /// <summary>
        /// Update or create currently position in databse.
        /// </summary>
        /// <param name="model">Position model.</param>
        /// <exception cref="PositionServicesException"></exception>
        public void Update(PositionModel model)
        {
            if (model is null)
                throw new PositionServicesException("Position model is NULL!");
            else if(Get(model.Id) is null)
                Add(model);
            else
                repository.UpdatePosition(mapper.Map<Position>(model));
        }

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
        /// A method that checks whether the conditions for adding random position or positions to the member model.
        /// It also includes submethods that create, fill and connect a new position.
        /// </summary>
        /// <param name="member">MemberMode.</param>
        /// <exception cref="PositionServicesException"></exception>
        public void GenerateNewPositionInMember(MemberModel member, PositionsNames expectedPosition, byte expectedPositionCount)
        {
            if (member.Positions.Count >= memberMaxPositionCountConst)
                throw new PositionServicesException("Member already know maximum positions he can!");
            else if (member.Positions.FirstOrDefault(x => x.Name == expectedPosition) != null)
                throw new PositionServicesException("Member already can play this position!");
            else
            {
                if (member.Positions.Count == 0)
                {
                    var position = CreatePositionInMember(member, expectedPosition);
                    member.Positions.Add(position);
                    Update(position);
                }
                if (member.Positions.Count < (int)expectedPositionCount)
                {
                    var randomPositionName = GetNewRandomPositionName();
                    var position = CreatePositionInMember(member, randomPositionName);
                    member.Positions.Add(position);
                    Update(position);
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
            Add(position);
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

            if (position.Power < 0)
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
