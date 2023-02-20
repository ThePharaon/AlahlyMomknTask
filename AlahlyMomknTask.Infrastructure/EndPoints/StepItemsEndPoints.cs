using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.EndPoints
{
    public class StepItemsEndPoints
    {
        public const string List = BaseEndPoints.StepItemsController + "GetAll";
        public const string GetByID = BaseEndPoints.StepItemsController + "GetByID";
        public const string Create = BaseEndPoints.StepItemsController + "Create";
        public const string Update = BaseEndPoints.StepItemsController + "Update";
        public const string Delete = BaseEndPoints.StepItemsController + "Delete";
    }
}
