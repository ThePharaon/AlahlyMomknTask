using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.Managers
{
    public interface IUserManager
    {
        Task<ResponseResults<User>> LoginAsync(LoginData loginData);
    }
}
