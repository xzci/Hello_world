using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    class HRoperate
    {
        public static void OpenExcel()
        {
            // open default excel
        }

        public static void OpenExcel(string filename)
        {
            // open specific excel
        }

        public static Dictionary<EmployeeId,Employee> UpDateFromExcl()
        {
            // read information from excel and get into memory
            // meke it becaome a dictionary

            var employees = new Dictionary<EmployeeId, Employee>();
            return employees;

        }

        public static void UpDate(Dictionary<EmployeeId,Employee> employees, EmployeeId id)
        {
            // update all the information
        }


       

        public static void WriteToExcel(Dictionary<EmployeeId, Employee> employees)
        {
            // write one information to excel
        }

        public static void WriteToExcel(EmployeeId id, Employee e)
        {
            // write single person to excel
        }
    }
}
