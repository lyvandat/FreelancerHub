using AutoMapper;
using DeToiServerCore.Models.SevicesUIElement;

namespace DeToiServer.Services.UIElementService
{
    public class UIElementServiceRequirementService : IUIElementServiceRequirementService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public UIElementServiceRequirementService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UIElementServiceRequirement>> GetAllWithDetail()
        {
            return await _uow.UIElementServiceRequirementRepo.GetAllWithDetail();
        }
    }
}
