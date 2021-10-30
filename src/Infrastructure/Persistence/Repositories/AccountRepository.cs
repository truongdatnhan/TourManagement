using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class AccountRepository : EFRepository<AppUser>, IAccountRepository
    {
        public AccountRepository(TourContext context) : base(context)
        {
        }
    }
}