using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.EndPoints
{
    public class TabStepsEndPoints
    {
        public const string List = BaseEndPoints.TabStepsController + "GetAll";
        public const string Create = BaseEndPoints.TabStepsController + "Create";
        public const string Update = BaseEndPoints.TabStepsController + "Update";
        public const string Delete = BaseEndPoints.TabStepsController + "Delete";
    }
}
