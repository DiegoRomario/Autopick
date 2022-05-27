using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Team : Entity
    {
        private Team() { }
        public Team(string name, Guid modalityId)
        {
            Name = name;
            ModalityId = modalityId;
            Players = new List<Player>();
        }
        public string Name { get; set; }
        public Guid ModalityId { get; private set; }
        public Modality Modality { get; private set; }
        public ICollection<Player> Players { get; private set; }
        public int Overall { get; private set; }
        public ICollection<Match> Matches { get; private set; }
        public ICollection<PlayerTeam> PlayerTeam { get; private set; }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
        public void SetPlayers(ICollection<Player> players)
        {
            Players = players;
        }
        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public void RemovePlayers()
        {
            Players.Clear();
        }
        public void CalculateOverall()
        {
            throw new NotImplementedException();
        }
    }
}
