using DeToiServerCore.Models.SevicesUIElement;

namespace DeToiServerData.Repositories.UIElementServiceRequirementRepo
{
    public interface IUIElementServiceRequirementRepo : IRepository<UIElementServiceRequirement>
    {
        Task<IEnumerable<UIElementServiceRequirement>> GetAllWithDetail();
    }

    public interface IUIElementAdditionServiceRequirementRepo : IRepository<UIElementAdditionServiceRequirement>
    {

    }
}
