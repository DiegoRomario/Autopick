using Autopick.Api.Domain.Enumerators;

namespace Autopick.Api.Models
{
    public class PlayerModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public EFoot Foot { get; set; }
        public double Height { get; set; } = 170;
        public double Weight { get; set; } = 70;

    }
}
