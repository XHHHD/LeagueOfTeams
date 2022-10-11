using LOT.BLL.Models.Members;

namespace LOT.BLL.Services.Members
{
    public static class NickGenerator
    {
        private static Random random = new();

        /// <summary>
        /// Get free random nick from default nick collection wich is free to use.
        /// </summary>
        /// <returns>String Nick</returns>
        internal static string GenerateNewNick()
        {
            HashSet<int> usedNamesIndexes = new HashSet<int>();
            if (MemberService.GetAll() == null)
            {
                return RandomNewNick();
            }
            foreach (MemberModel member in MemberService.GetAll())
            {
                if (DefaultNicksSource.nicksList.IndexOf(member.Name) != -1)
                    usedNamesIndexes.Add(DefaultNicksSource.nicksList.IndexOf(member.Name));
            }
            var notUsedIndexes = Enumerable.Range(0, DefaultNicksSource.nicksList.Count - 1)
                .Where(i => !usedNamesIndexes.Contains(i));
            int randomNameIndexForNotUsedInexes;
            if (notUsedIndexes.Count() > 0)
            {
                randomNameIndexForNotUsedInexes = random.Next(0, notUsedIndexes.Count());
                return DefaultNicksSource.nicksList[notUsedIndexes.ElementAt(randomNameIndexForNotUsedInexes)];
            }
            else
            {
                string name;
                int sufix;
                name = RandomNewNick();
                do
                {
                    sufix = random.Next(0, 10);
                }while (IsThisNickIsFree((name + sufix).ToString()));
                return (name + sufix).ToString();
            }
        }

        /// <summary>
        /// Get random nick from default nick collection.
        /// </summary>
        /// <returns>String Nick</returns>
        private static string RandomNewNick() =>
            DefaultNicksSource.nicksList[random.Next(0, DefaultNicksSource.nicksList.Count())];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nick"></param>
        /// <returns>True, if nick is free to use.</returns>
        internal static bool IsThisNickIsFree(string nick)
        {
            var members = MemberService.GetAll();
            foreach (MemberModel member in members)
            {
                if (member.Name == nick)
                    return false;
            }
            return true;
        }
    }
}
