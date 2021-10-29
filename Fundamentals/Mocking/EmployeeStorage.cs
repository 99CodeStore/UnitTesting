using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Mocking
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeDataContext _db;
        public EmployeeStorage()
        {
            _db = new EmployeeDataContext();
        }
        public void DeleteEmployee(int Id)
        {
            var employee = _db.Employees.FirstOrDefault(e => e.ID == Id);
            if (employee == null) return;

            _db.Employees.DeleteOnSubmit(employee);

            _db.SubmitChanges();
        }
    }
}
