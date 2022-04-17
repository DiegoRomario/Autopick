using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class PlayerOverall : Entity
    {
        private PlayerOverall() { }
        public PlayerOverall(Guid playerId, Guid modalityId)
        {
            PlayerId = playerId;
            ModalityId = modalityId;
            PlayerSkillRatings = new List<PlayerSkillRating>();
            MapSkills();
            Overall = 0;
        }
        public Guid PlayerId { get; private set; }
        public Player Player { get; private set; }
        public Guid ModalityId { get; private set; }
        public Modality Modality { get; private set; }
        public ICollection<PlayerSkillRating> PlayerSkillRatings { get; private set; }
        public int Overall { get; private set; }

        private void MapSkills()
        {
            Modality.Skills.ToList().ForEach(s => PlayerSkillRatings.Add(new PlayerSkillRating(Id, s.Id)));
        }
        private void CalculateOverall()
        {
            Overall = PlayerSkillRatings.Sum(s => s.Rating);
        }

    }
}
