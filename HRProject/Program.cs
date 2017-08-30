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

   
    class Program
    {
        public static void Logger(string lines, string context)
        {

            // Write Log
            var fileName = string.Format("{0}//log.txt", Directory.GetCurrentDirectory());
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\.txt", true);
            file.WriteLine(lines + ": " + context);

            file.Close();

        }

       
        
        static void Main(string[] args)
        {
            // Get Input File, Now it is Hard Code, should Change it.
            var fileName = string.Format("{0}\\1.xlsx", Directory.GetCurrentDirectory());

            //Console.WriteLine(fileName);
            
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";", fileName);

            Logger("36", "Open Excel");
            
            
            var adapter = new OleDbDataAdapter("SELECT * FROM [sheet1$]", connectionString);

            var ds = new DataSet();

            //adapter.Fill(ds, "anyNameHere");
            #region need to rebuild
            adapter.Fill(ds, "Excel");

            DataTable myTestDT = ds.Tables["Excel"];

            foreach (DataColumn i in myTestDT.Columns)
            {
                Console.Write(i.ColumnName);
                Console.Write("  ");
            }

            Console.WriteLine();

            foreach (DataRow i in myTestDT.Rows)
            {
                foreach (var r in i.ItemArray)
                {
                    Console.Write(r);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            #endregion



        }
    }
}
