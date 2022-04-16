using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public Modality Modality { get; private set; }
        public IList<Player> Players { get; set; }
        public int Overall { get; set; }
    }
}
