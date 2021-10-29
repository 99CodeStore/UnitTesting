using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Mocking
{
    public class EmployeeFaultyController
    {
        private EmployeeDataContext _db;
        public EmployeeFaultyController()
        {
            _db = new EmployeeDataContext();
        }

        public ActionResult Delete(int Id)
        {
            var employee = _db.Employees.FirstOrDefault(e => e.ID == Id);

            _db.Employees.DeleteOnSubmit(employee);

            _db.SubmitChanges();

            return RedirectToAction();
        }

        private static ActionResult RedirectToAction()
        {
            return new RedirectResult();
        }
    }
   
}
