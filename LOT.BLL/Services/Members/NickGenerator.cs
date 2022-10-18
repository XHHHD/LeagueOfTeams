using LOT.BLL.Models.Members;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Members
{
    public class NickGenerator
    {
        private readonly Random random;
        private readonly MemberRepository repository;

        public NickGenerator()
        {
            random = new();
            repository = new();
        }

        /// <summary>
        /// Get free random nick from default nick collection wich is free to use.
        /// </summary>
        /// <returns>String Nick</returns>
        internal string GenerateNewNick()
        {
            HashSet<int> used = new HashSet<int>();
            //
            if (repository.GetAll() == null)
            {
                return RandomNewNick();
            }
            //
            else
            {
                foreach (string name in repository.GetAllNames())
                {
                    if (DefaultNicksSource.nicksList.IndexOf(name) != -1)
                        used.Add(DefaultNicksSource.nicksList.IndexOf(name));
                }
                //
                var notUsed = Enumerable
                    .Range(0, DefaultNicksSource.nicksList.Count - 1)
                    .Where(i => !used.Contains(i));
                //
                int randomFromNotUsed;
                if (notUsed.Count() > 0)
                {
                    randomFromNotUsed = random
                        .Next(0, notUsed.Count());
                    
                    return DefaultNicksSource
                        .nicksList[notUsed
                        .ElementAt(randomFromNotUsed)];
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
        }

        /// <summary>
        /// Get random nick from default nick collection.
        /// </summary>
        /// <returns>String Nick</returns>
        private string RandomNewNick() =>
            DefaultNicksSource.nicksList[random.Next(0, DefaultNicksSource.nicksList.Count)];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nick"></param>
        /// <returns>True, if nick is free to use.</returns>
        internal bool IsThisNickIsFree(string nick)
        {
            var names = repository.GetAllNames();
            foreach (string name in names)
            {
                if (name == nick)
                    return false;
            }
            return true;
        }
    }
}
