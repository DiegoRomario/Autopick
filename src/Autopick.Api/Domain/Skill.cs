using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Skill : Entity
    {
        private Skill() { }
        public Skill(string name, string description, Guid modalityId)
        {
            Name = name;
            Description = description;
            ModalityId = modalityId;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ModalityId { get; private set; }
        public Modality Modality { get; private set; }
        public ICollection<PlayerSkillRating> PlayerRatings { get; private set; }
    }
}
