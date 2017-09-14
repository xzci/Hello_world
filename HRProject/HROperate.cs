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
        public static string GetemploymentType(EmployeeId id)
        {
            // !need to finish get employmentType from the EmploymentID :<

            string s = "";

            return s;
        }

        public static void InitNewExcel()
        {
            // !open default excel to create a datatable
            // !need to do these:
            // !create a excel as new file, then write the headers in the excel
            // !maybe will add some funcation which add colors and so on
        }

        public static DataTable OpenExcel(string filename, string sheetname)
        {
            // open specific excel to datatable

            var fileName = string.Format("{0}\\{1}.xlsx", Directory.GetCurrentDirectory(), filename);
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";", fileName);

            Log.Logger("OpenExcel", "Open Excel");

            var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetname + "$]", connectionString);

            var ds = new DataSet();
            adapter.Fill(ds, "Excel");
            DataTable myTestDT = ds.Tables["Excel"];
            
            // adapter.Fill(ds, "anyNameHere");
            return myTestDT;

        }

        public static Dictionary<EmployeeId,Employee> UpDateFromExcl(string filename, string sheetname)
        {
            // read information from excel and get all data into dictionary
            

            DataTable employeeDataTable = OpenExcel(filename, sheetname);

            Contract.Requires<ArgumentNullException>(employeeDataTable.Rows.Count != 0);

            var employees = new Dictionary<EmployeeId, Employee>();

            foreach (DataRow row in employeeDataTable.Rows)
            {
                // !add employment can automatic build from employeeid

                Employee e = new Employee();
                EmployeeId id = new EmployeeId(row["emid"].ToString());
                e.EmploymentType = row["EmploymentType"].ToString();
                e.Name = row["Name"].ToString();
                e.ID = row["ID"].ToString();
                e.Gender = row["Gender"].ToString();
                e.Brithday = DateTime.Parse(row["Birthday"].ToString());
                e.City = row["City"].ToString();
                e.Email = row["Email"].ToString();
                e.AccountName = row["AccountName"].ToString();
                e.BankAccount = row["BankAccount"].ToString();

                e.FormlyCompany = row["FormlyCompany"].ToString();
                e.HireDate = DateTime.Parse(row["HireDate"].ToString());
                e.Domain = row["Doamin"].ToString();
                e.Team = row["Team"].ToString();
                e.JobTitle = row["JobTitle"].ToString();
                e.JobCode = row["JobCode"].ToString();
                e.CompanyEmail = row["CompanyEmail"].ToString();
                e.StartWorkingDate = DateTime.Parse(row["StartWorkingDate"].ToString());
                e.LastWorkingDate = DateTime.Parse(row["LastWorkingDate"].ToString());
                e.WorkExperience = Convert.ToInt32(row["WorkExperience"]);
                
                employees.Add(id, e);
                Log.Logger("80", id.ToString() + "has been read");
            }

            return employees;

        }

        public static Employee UpateOne()
        {
            //! finished it soon :<

            Employee e = new Employee();

            Console.WriteLine("Please chose which data you want change");
            string chose;
            chose = Console.ReadLine();
            

            switch (chose)
            {
                case "d":
                    {
                        string someValue = Console.ReadLine();
                        e.City = someValue;
                        break;
                    }
                case " ":
                    {
                        break;
                    }
            }


            return e;
        }

        public static Employee UpateOne(Employee e)
        {
            // !finished it soon :< 
            Console.WriteLine("Please chose which data you want change");
            string option;
            option = Console.ReadLine();
          

            switch (option)
            {
                case "d":
                    {
                        string city = Console.ReadLine();
                        e.City = city;
                        break;
                    }
                case " ":
                    {
                        break;
                    }
            }


            return e;
        }

        public static void UpDate(Dictionary<EmployeeId,Employee> employees, EmployeeId id)
        {
            // update all the information if id in dictionary upate the data, if not, add data
            // to dictionary
            // get input or something to check the data whether need to been changed
            // 

            if(employees.ContainsKey(id))
            {
                employees[id] = UpateOne(employees[id]);
            }
            else
            {
                employees.Add(id, UpateOne());
            }

            // need a chickBox to Update the informaiton
           
        }

        
        public static void WriteToExcel(Dictionary<EmployeeId, Employee> employees)
        {
            // write one information to excel
        }

        

       

        

    }
}
