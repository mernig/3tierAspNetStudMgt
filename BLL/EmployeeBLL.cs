using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class EmployeeBLL 
    {
        private implEmployee emplObj;
        public EmployeeBLL()
        {
            emplObj = new implEmployee();
        }
        public void DeleteEmployeeBL(string id)
        {
            Employee empl = emplObj.GetEmplByID(id);
            emplObj.DeleteEmployee(id);
        }

        public Employee GetEmplByIDBL(string id)
        {
            return emplObj.GetEmplByID(id);
        }

        public IEnumerable<Employee> GetEmployeeBL()
        {
            return emplObj.GetEmployee();
        }

        public void InsertEmployeeBL(Employee empl)
        {
            emplObj.InsertEmployee(empl);
        }

        public void SaveBL()
        {
            emplObj.Save();
        }

        public void UpdateEmployeeBL(Employee empl)
        {
            emplObj.UpdateEmployee(empl);
        }
    }
}
