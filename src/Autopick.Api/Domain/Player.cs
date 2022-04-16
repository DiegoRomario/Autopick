using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Player : Entity
    {
        public Player(string name, DateOnly birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public IList<PlayerOverall> PlayerOveralls { get; private set; }
    }
}
