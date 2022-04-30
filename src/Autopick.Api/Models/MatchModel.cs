namespace Autopick.Api.Models
{
    public class MatchModel : BaseModel
    {
        public DateTime Date { get; set; }
        public Guid ModalityId { get; set; }
        public Guid GroupId { get; set; }

    }
}
