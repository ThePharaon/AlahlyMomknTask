using AlahlyMomknTask.Enums.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Models.Request
{
    public class ResponseResults<TModel>
    {
        public TModel Result { get; set; }
        public APIReturnStatus Status { get; set; }
    }
}
