﻿using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IApplicationUserRepository : IAsyncRepository<ApplicationUser>
    {
    }
}
