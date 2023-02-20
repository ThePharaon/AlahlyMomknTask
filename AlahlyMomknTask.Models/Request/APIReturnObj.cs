using AlahlyMomknTask.Enums.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Models.Request
{
    public class APIReturnObj<TModel>
    {
        public TModel ReturnValue { get; set; }
        public APIReturnStatus Status { get; set; }
        public string Message { get; set; }
    }
}
