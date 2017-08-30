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
        public void Logger(String lines)
        {

            // Write the string to a file.append mode is enabled so that the log
            // lines get appended to  test.txt than wiping content and writing the log

            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt", true);
            file.WriteLine(lines);

            file.Close();

        }
        static void Main(string[] args)
        {
            var fileName = string.Format("{0}\\1.xlsx", Directory.GetCurrentDirectory());

            //Console.WriteLine(fileName);
            
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";", fileName);



            var adapter = new OleDbDataAdapter("SELECT * FROM [sheet1$]", connectionString);
            var ds = new DataSet();

            //adapter.Fill(ds, "anyNameHere");
            adapter.Fill(ds, "1");

            DataTable myTestDT = ds.Tables["1"];


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

        }
    }
}
