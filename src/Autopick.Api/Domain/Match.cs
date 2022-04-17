using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Match : Entity
    {
        private Match() { }
        public Match(DateTime date, Guid modalityId, Guid groupId)
        {
            Date = date;
            ModalityId = modalityId;
            GroupId = groupId;
            Teams = new List<Team>();
        }

        public DateTime Date { get; private set; }
        public Guid ModalityId { get; private set; }
        public Modality Modality { get; private set; }
        public Guid GroupId { get; private set; }
        public Group Group { get; private set; }
        public ICollection<Team> Teams { get; private set; }
        public void GenerateTeams()
        {
            throw new NotImplementedException();
        }

    }
}
