using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface ILogUserRepository : IAsyncRepository<LogUser>
    {
    }
}
