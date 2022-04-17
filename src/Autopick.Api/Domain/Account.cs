using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Account : Entity
    {
        private Account() { }
        public Account(string email)
        {
            Email = email;
        }
        public string Email { get; private set; }
        public virtual ICollection<Group> Groups { get; private set; }

    }
}
