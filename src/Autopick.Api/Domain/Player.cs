using Autopick.Api.Domain.Base;
using Autopick.Api.Domain.Enumerators;

namespace Autopick.Api.Domain
{
    public class Player : Entity
    {
        private Player() { }

        public Player(string name, DateTime birthDate, EFoot foot, double height, double weight)
        {
            Name = name;
            BirthDate = birthDate;
            Foot = foot;
            Height = height;
            Weight = weight;
        }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public EFoot Foot { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
        public ICollection<PlayerOverall> PlayerOveralls { get; private set; }
        public ICollection<PlayerSkillRating> PlayerRatings { get; private set; }
        public ICollection<Team> Teams { get; private set; }
        public ICollection<Group> Groups { get; private set; }
        public ICollection<PlayerTeam> PlayerTeam { get; private set; }
    }
}
