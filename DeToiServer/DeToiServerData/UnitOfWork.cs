using DeToiServerData.Repositories;
using DeToiServerData.Repositories.CleaningServiceRepo;
using DeToiServerData.Repositories.OrderRepo;
using DeToiServerData.Repositories.PromotionRepo;
using DeToiServerData.Repositories.RepairingServiceRepo;
using DeToiServerData.Repositories.ServiceCategoryRepo;
using DeToiServerData.Repositories.ServiceTypeRepo;
using DeToiServerData.Repositories.ShoppingServiceRepo;
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

        #region Service
        private IServiceTypeRepo _serviceTypeRepo;
        public IServiceTypeRepo ServiceTypeRepo
        {
            get
            {
                _serviceTypeRepo ??= new ServiceTypeRepo(_dataContext);
                return _serviceTypeRepo;
            }
        }
        #endregion

        #region ServiceCategory
        private IServiceCategoryRepo _serviceCategoryRepo;
        public IServiceCategoryRepo ServiceCategoryRepo
        {
            get
            {
                _serviceCategoryRepo ??= new ServiceCategoryRepo(_dataContext);
                return _serviceCategoryRepo;
            }
        }
        #endregion

        #region Promotion
        private IPromotionRepo _promotionRepo;
        public IPromotionRepo PromotionRepo
        {
            get
            {
                _promotionRepo ??= new PromotionRepo(_dataContext);
                return _promotionRepo;
            }
        }
        #endregion

        #region Order
        private IOrderRepo _orderRepo;
        public IOrderRepo OrderRepo
        {
            get
            {
                _orderRepo ??= new OrderRepo(_dataContext);
                return _orderRepo;
            }
        }
        #endregion

        #region Service Repo
        private ICleaningServiceRepo _cleaningServiceRepo;
        public ICleaningServiceRepo CleaningRepo
        {
            get
            {
                _cleaningServiceRepo ??= new CleaningServiceRepo(_dataContext);
                return _cleaningServiceRepo;
            }
        }

        private IShoppingServiceRepo _shoppingServiceRepo;
        public IShoppingServiceRepo ShoppingRepo
        {
            get
            {
                _shoppingServiceRepo ??= new ShoppingServiceRepo(_dataContext);
                return _shoppingServiceRepo;
            }
        }

        private IRepairingServiceRepo _repairingServiceRepo;
        public IRepairingServiceRepo RepairingRepo
        {
            get
            {
                _repairingServiceRepo ??= new RepairingServiceRepo(_dataContext);
                return _repairingServiceRepo;
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
