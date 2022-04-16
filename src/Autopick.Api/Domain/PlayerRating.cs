using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class PlayerRating : Entity
    {
        public PlayerRating(Player player, Modality modality, Skill skill)
        {
            Player = player;
            Modality = modality;
            Skill = skill;
            Rating = 0;
        }

        public Player Player { get; private set; }
        public Modality Modality { get; private set; }
        public Skill Skill { get; private set; }
        public int Rating { get; private set; }
    }
}
