using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Server.Services;

namespace AlahlyMomknTask.Server.Repositories
{

    public interface ITabStepRepository : IBaseRepository<TabStep>
    {

    }
    public class TabStepRepository : BaseRepository<TabStep>, ITabStepRepository
    {
        public TabStepRepository(MainDBContext context) : base(context)
        {

        }
    }
}
