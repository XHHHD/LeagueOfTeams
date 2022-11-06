using LOT.DAL.Entities;

namespace LOT.DAL.Repositories
{
    public class PositionNameRepository
    {
        internal readonly List<string> positions = new() { "Topline", "Jungley", "Midline", "Botline", "Support" };
        public string GetCurrentlyPositionName(int posotionIndex)
        {
            return positions[posotionIndex];
        }
    }
}
