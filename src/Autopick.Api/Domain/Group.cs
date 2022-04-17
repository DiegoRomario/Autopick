using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Group : Entity
    {
        private Group() { }
        public Group(string name, Guid accountId)
        {
            Name = name;
            AccountId = accountId;
            Players = new List<Player>();
        }
        public string Name { get; private set; }
        public Guid AccountId { get; private set; }
        public Account Account { get; private set; }
        public ICollection<Player> Players { get; private set; }
        public ICollection<Match> Matches { get; private set; }
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
