using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Server.Services;

namespace AlahlyMomknTask.Server.Repositories
{

    public interface IStepItemRepository : IBaseRepository<StepItem>
    {

    }
    public class StepItemRepository : BaseRepository<StepItem>, IStepItemRepository
    {
        public StepItemRepository(MainDBContext context) : base(context)
        {

        }
    }
}
