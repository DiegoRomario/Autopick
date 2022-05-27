using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class PlayerTeam : Entity
    {
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
