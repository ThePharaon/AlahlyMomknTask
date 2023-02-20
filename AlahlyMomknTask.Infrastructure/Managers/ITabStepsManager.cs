using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;

namespace AlahlyMomknTask.Infrastructure.Managers
{
    public interface ITabStepsManager : ICommon<TabStep>
    {
        Task<ResponseResults<List<TabStep>>> GetListAsync();
    }
}
