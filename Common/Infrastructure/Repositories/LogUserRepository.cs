using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class LogUserRepository : RepositoryBase<LogUser>, ILogUserRepository
    {
        public LogUserRepository(HazarAuthDbContext dbContext) : base(dbContext)
        {
        }
    }
}
