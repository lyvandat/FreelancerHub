using DeToiServerCore.Models.SevicesUIElement;

namespace DeToiServer.Services.UIElementService
{
    public interface IUIElementServiceRequirementService
    {
        public Task<IEnumerable<UIElementServiceRequirement>> GetAllWithDetail();
    }
}
