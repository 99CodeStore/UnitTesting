using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage _employeeStorage;

        public EmployeeController(IEmployeeStorage employeeStorage)
        {
            this._employeeStorage = employeeStorage;
        }

        public ActionResult Delete(int Id)
        {

            _employeeStorage.DeleteEmployee(Id);

            return RedirectToAction();
        }

        private ActionResult RedirectToAction()
        {
            return new RedirectResult();
        }
    }

    public class RedirectResult : ActionResult { }
}
