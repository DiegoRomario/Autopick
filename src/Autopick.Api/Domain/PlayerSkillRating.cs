using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class PlayerSkillRating : Entity
    {
        private PlayerSkillRating() { }
        public PlayerSkillRating(Guid playerOverallId, Guid skillId)
        {
            PlayerOverallId = playerOverallId;
            SkillId = skillId;
            Rating = 0;
        }
        public Guid PlayerOverallId { get; private set; }
        public PlayerOverall PlayerOverall { get; private set; }
        public Guid SkillId { get; private set; }
        public Skill Skill { get; private set; }
        public int Rating { get; private set; }
    }
}
