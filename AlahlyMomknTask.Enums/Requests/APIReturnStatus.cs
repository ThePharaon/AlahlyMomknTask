using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Enums.Requests
{
    public enum APIReturnStatus
    {
        Success,
        NotFound,
        BadRequest,
        NotActive,
        NotAvailable,
        WrongUser,
        WrongPassword,
        ExistBefore,
        NotAuthorized,
        InternalError
    }
}
