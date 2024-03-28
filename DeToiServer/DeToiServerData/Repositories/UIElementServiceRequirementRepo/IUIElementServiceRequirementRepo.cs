using DeToiServerCore.Models.SevicesUIElement;

namespace DeToiServerData.Repositories.UIElementServiceRequirementRepo
{
    public interface IUIElementServiceRequirementRepo : IRepository<UIElementServiceRequirement>
    {
        Task<IEnumerable<UIElementServiceRequirement>> GetAllWithDetail();
        Task<IEnumerable<UIElementServiceRequirement>> GetAllWithIcon(Guid serviceTypeId);
    }

    public interface IUIElementAdditionServiceRequirementRepo : IRepository<UIElementAdditionServiceRequirement>
    {
        Task<IEnumerable<UIElementAdditionServiceRequirement>> GetAllWithIcon(Guid serviceTypeId);
    }
}
