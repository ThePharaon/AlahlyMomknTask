using AlahlyMomknTask.Enums.Requests;
using AlahlyMomknTask.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.Managers
{
    public interface ICommon<T>
    {
        Task<APIReturnStatus> CreateAsync(T entity);
        Task<APIReturnStatus> UpdateAsync(T entity);
        Task<APIReturnStatus> DeleteAsync(Guid ID);
    }
}
