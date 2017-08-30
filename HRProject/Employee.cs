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

        private string employmentType;

        private int workExperience;

        private string domain;

        private string team;

        private string jobTitle;

        private string jobcode;

        private string companyEmail;

        private DateTime hireDate;
        #endregion

        public DateTime LastWorkingDate { get { return lastWorkingDate; } set { lastWorkingDate = value; } }

        public DateTime StartWorkingDate { get { return startWorkingDate; } set { startWorkingDate = value; } }

        public DateTime HireDate { get { return hireDate; } set { hireDate = value; } }

        public string Domain { get { return domain; } set { domain = value; } }

        public string Team { get { return team; } set { team = value; } }

        public string JobTitle { get { return jobTitle; } set { jobTitle = value; } }

        public string JobCode { get { return jobcode; }  set { jobcode = value; } }

        public string CompanyEmail { get { return companyEmail; } set { companyEmail = value; } }

        public int WorkExperience { get { return workExperience; } set { workExperience = value; } }

        public string EmploymentType { get { return employmentType; } set { employmentType = value; } }



        public override void GetTermination()
        {

            //delete the one from the excel who call this funtaion.

            // and write all these informaion to Termination sheet
            
        }

    }
}
