using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Contracts;




namespace HRProject
{
    public class HROperate
    {
        public static void InitNewExcel()
        {
            // open default excel to datatable
        }

        public static DataTable OpenExcel(string filename, string sheetname)
        {

            // open specific excel to datatable
            var fileName = string.Format("{0}\\{1}.xlsx", Directory.GetCurrentDirectory(), filename);

            // Console.WriteLine(fileName);

            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";", fileName);

            Log.Logger("26", "Open Excel");

            
            var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetname + "$]", connectionString);

            var ds = new DataSet();
            adapter.Fill(ds, "Excel");
            DataTable myTestDT = ds.Tables["Excel"];
            // adapter.Fill(ds, "anyNameHere");
            return myTestDT;

        }

        public static Dictionary<EmployeeId,Employee> UpDateFromExcl(string filename, string sheetname)
        {
            // read information from excel and get into memory
            // meke it becaome a dictionary

            DataTable employeeDataTable = OpenExcel(filename, sheetname);

            Contract.Requires<ArgumentNullException>(employeeDataTable.Rows.Count != 0);

            var employees = new Dictionary<EmployeeId, Employee>();

            foreach (DataRow row in employeeDataTable.Rows)
            {
                Employee e = new Employee();
                EmployeeId id = new EmployeeId(row["emid"].ToString());
                e.Name = row["Name"].ToString();
                e.ID = row["ID"].ToString();
                e.City = row["City"].ToString();
                e.Brithday = DateTime.Parse(row["Birthday"].ToString());
                e.AccountName = row["AccountName"].ToString();
                e.BankAccount = row["BankAccount"].ToString();
                e.Gender = row["Gender"].ToString();
                e.HireDate = DateTime.Parse(row["HireDate"].ToString());
                e.WorkExperience = Convert.ToInt32(row["WorkExperience"]);
                e.JobCode = row["JobCode"].ToString();
                e.JobTitle = row["JobTitle"].ToString();
                e.Team = row["Team"].ToString();
                e.CompanyEmail = row["CompanyEmail"].ToString();
                e.StartWorkingDate = DateTime.Parse(row["StartWorkingDate"].ToString());
                e.LastWorkingDate = DateTime.Parse(row["LastWorkingDate"].ToString());
                e.Email = row["Email"].ToString();
                e.Domain = row["Doamin"].ToString();
                e.FormlyCompany = row["FormlyCompany"].ToString();
                employees.Add(id, e);
                Log.Logger("80", id.ToString());
            }

            return employees;

        }

        public static void UpDate(Dictionary<EmployeeId,Employee> employees, EmployeeId id)
        {
            // update all the information if id in dictionary upate the data, if not, add data
            // to dictionary
            // get input or something to check the data whether need to been changed
            // 
            Employee e = new Employee();

            employees[id] = e;


        }


        public void Test()
        { }


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
