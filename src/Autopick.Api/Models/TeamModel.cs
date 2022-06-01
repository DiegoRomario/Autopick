namespace Autopick.Api.Models
{
    public class TeamModel : BaseModel
    {
        public string Name { get; set; }
        public Guid ModalityId { get; set; }
        public ModalityModel Modality { get; private set; }
        public ICollection<PlayerModel> Players { get; set; }
        public int Overall { get; private set; }
    }
}
