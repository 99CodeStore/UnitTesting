using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            if (id==0)
            {
                return new NotFound();
            }
            return new OK();
        }
    }
    public class ActionResult { }
    public class OK:ActionResult { }
    public class NotFound : ActionResult { }
}
