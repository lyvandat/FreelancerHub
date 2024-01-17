using DeToiServerData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DeToiServerData
{
    public class UnitOfWork
    {
        readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Account
        private IAccountRepo _accountRepo;
        public IAccountRepo AccountRepo
        {
            get
            {
                _accountRepo ??= new AccountRepo(_dataContext);
                return _accountRepo;
            }
        }
        #endregion

        public async Task<bool> SaveChangesAsync()
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                var result = await _dataContext.SaveChangesAsync();
                scope.Complete();
                return result > 0;
            }
            catch (Exception)
            {
                scope.Dispose();
                return false;
            }
        }

        public List<string> SaveChanges()
        {
            var errors = new List<string>();
            try
            {
                _dataContext.SaveChanges();
                return errors;
            }
            catch (Exception ex)
            {
                var currentEx = ex;
                do
                {
                    errors.Add(currentEx.Message);
                    if (currentEx.InnerException == null)
                        break;
                    currentEx = currentEx.InnerException;
                } while (true);
                return errors;
            }
        }
    }
}
