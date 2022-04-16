using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Match : Entity
    {
        public Match(DateTime date, Modality modality, Group group)
        {
            Date = date;
            Modality = modality;
            Group = group;
            Teams = new List<Team>();
        }

        public DateTime Date { get; private set; }
        public Modality Modality { get; private set; }
        public Group Group { get; private set; }
        public IList<Team> Teams { get; private set; }

        public void GenerateTeams()
        {
            throw new NotImplementedException();
        }

    }
}
