using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HRProject
{
    class Log
    {
        public static void Logger(string lines, string context)
        {

            // Write Log
            var fileName = string.Format("{0}//log.txt", Directory.GetCurrentDirectory());
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\.txt", true);
            file.WriteLine(lines + ": " + context);
            file.Close();

        }
    }
}
