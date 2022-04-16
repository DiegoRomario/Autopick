using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Group : Entity
    {
        public Group(Account account, string name)
        {

            Account = account;
            Name = name;
            Players = new List<Player>();
        }
        public Account Account { get; private set; }
        public string Name { get; private set; }
        public IList<Player> Players { get; private set; }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

    }
}
