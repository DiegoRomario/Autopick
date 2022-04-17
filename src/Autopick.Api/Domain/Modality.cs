using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Modality : Entity
    {
        private Modality() { }
        public Modality(string name, string description)
        {
            Name = name;
            Description = description;
            Skills = new List<Skill>();
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<Skill> Skills { get; private set; }
        public ICollection<Match> Matches { get; private set; }
        public ICollection<PlayerOverall> PlayerOveralls { get; private set; }
        public ICollection<PlayerSkillRating> PlayerRatings { get; private set; }
        public ICollection<Team> Teams { get; private set; }
        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }
        public void RemoveSkill(Skill skill)
        {
            Skills.Remove(skill);
        }
    }
}
