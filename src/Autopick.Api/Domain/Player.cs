using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Player : Entity
    {
        private Player() { }
        public Player(string name, DateOnly birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public ICollection<PlayerOverall> PlayerOveralls { get; private set; }
        public ICollection<PlayerSkillRating> PlayerRatings { get; private set; }
        public ICollection<Team> Teams { get; private set; }
        public ICollection<Group> Groups { get; private set; }
    }
}
