using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class PlayerOverall : Entity
    {
        public PlayerOverall(Player player, Modality modality)
        {
            Player = player;
            Modality = modality;
            SkillsRated = new List<PlayerRating>();
            MapSkills();
        }

        public Player Player { get; private set; }
        public Modality Modality { get; private set; }
        public IList<PlayerRating> SkillsRated { get; private set; }
        public int Overall { get; private set; }

        private void MapSkills()
        {
            Modality.Skills.ToList().ForEach(s => SkillsRated.Add(new PlayerRating(Player, Modality, s)));
        }

        private void CalculateOverall()
        {
            Overall = SkillsRated.Sum(s => s.Rating);
        }

    }
}
