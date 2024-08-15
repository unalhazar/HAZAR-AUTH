using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(HazarAuthDbContext dbContext) : base(dbContext)
        {
        }
    }
}
