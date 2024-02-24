using DeToiServerCore.Models.Infos;

namespace DeToiServer.Dtos.ShoppingServiceDtos
{
    public class PostShoppingServiceDto : PostServiceDto
    {
        public ShoppingInfo? ShoppingInfo { get; set; }
    }
}
