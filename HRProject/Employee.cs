using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    class Employee : Person
    {
        #region Company Information
        private DateTime lastWorkingDate;

        private DateTime startWorkingDate;

        private DateTime hireDate;
        #endregion

        public DateTime LastWorkingDate { get { return lastWorkingDate; } set { lastWorkingDate = value; } }

        public DateTime StartWorkingDate { get { return startWorkingDate; } set { startWorkingDate = value; } }

        public DateTime HireDate { get { return HireDate; } set { hireDate = value; } }


        

    }
}
