using Autopick.Api.Domain.Base;

namespace Autopick.Api.Domain
{
    public class Account : Entity
    {
        public Account(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }
    }
}
