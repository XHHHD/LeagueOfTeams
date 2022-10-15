using AutoMapper;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Positions;
using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Members
{
    public class PositionService
    {
        private readonly IMapper mapper;
        private readonly PositionRepository repository = new();

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
    }
}
