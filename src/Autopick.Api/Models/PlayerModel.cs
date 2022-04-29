using Autopick.Api.Domain.Enumerators;

namespace Autopick.Api.Models
{
    public class PlayerModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public EFoot Foot { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

    }
}
