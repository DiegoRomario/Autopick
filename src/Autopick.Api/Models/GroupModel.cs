namespace Autopick.Api.Models
{
    public class GroupModel : BaseModel
    {
        public string Name { get; set; }
        public Guid AccountId { get; set; }
    }
}
