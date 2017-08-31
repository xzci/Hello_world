using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;

//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace HRProject
{


    public class Program
    {
        
        static void Main(string[] args)
        {

            /* 
            *  HR can read the new hired employees from [resume] or just type the each information
            *  into the program, and then the program should save the information to Excel.
            */

            Employee e = new Employee();
            e.Name = Console.ReadLine();

            EmployeeId id = new EmployeeId("E000001");
            var employees = new Dictionary<EmployeeId, Employee>();
            employees.Add(id, e);
            string filename = "Roster";
            string sheetname = "Roster";
            // get information from the excel
            employees = HROperate.UpDateFromExcl(filename, sheetname);

            HROperate.UpDate(employees,id);

            HROperate.WriteToExcel(employees);


            // Console.WriteLine(e);




            
            

            
        }
    }
}
