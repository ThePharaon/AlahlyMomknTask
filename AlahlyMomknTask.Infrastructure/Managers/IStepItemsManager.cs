using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;

namespace AlahlyMomknTask.Infrastructure.Managers
{
    public interface IStepItemsManager : ICommon<StepItem>
    {
        Task<ResponseResults<StepItem>> GetDetailsAsync(Guid ID);
        Task<ResponseResults<List<StepItem>>> GetListAsync(Guid StepID);
    }
}
