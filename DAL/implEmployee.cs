using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class implEmployee : EmployeeInterface
    {
        private ContextELearningDBEntities context;
        public implEmployee()
        {
            context = new ContextELearningDBEntities();
        }
        public void DeleteEmployee(string id)
        {
            Employee empl = context.Employees.Find(id);
            context.Employees.Remove(empl);
        }

        public Employee GetEmplByID(string id)
        {
            return context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return context.Employees.ToList();
        }

        public void InsertEmployee(Employee empl)
        {
            context.Employees.Add(empl);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee empl)
        {
            context.Entry(empl).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
