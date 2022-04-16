using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Modality : Entity
    {
        public Modality(string name, string description)
        {
            Name = name;
            Description = description;
            Skills = new List<Skill>();
        }
        public Modality(string name, string description, IList<Skill> skills)
        {
            Name = name;
            Description = description;
            Skills = skills;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public IList<Skill> Skills { get; private set; }

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
