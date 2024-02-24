using DeToiServerCore.Models.Services;

namespace DeToiServerData.Repositories.ShoppingServiceRepo
{
    public class ShoppingServiceRepo : RepositoryBase<ShoppingService>, IShoppingServiceRepo
    {
        private readonly DataContext _context;

        public ShoppingServiceRepo(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
