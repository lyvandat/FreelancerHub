﻿using DeToiServerCore.Models.Accounts;

namespace DeToiServerData.Repositories.AccountFreelanceRepo;

public interface IFreelanceAccountRepo : IRepository<FreelanceAccount>
{
    Task<FreelanceAccount> GetByAccId(Guid id);
}