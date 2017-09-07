using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
namespace HRProject
{
    public class EmployeeIdExcetion : Exception
    {
        public EmployeeIdExcetion(string message) : base(message) { }
    }

    public class Employee : Person
    {

        public Employee()
        {
            //
        }

        #region Company Information
        private readonly EmployeeId emID;

        private DateTime lastWorkingDate;

        private DateTime startWorkingDate;

        private string employmentType;

        private int workExperience;

        private string domain;

        private string team;

        private string jobTitle;

        private string jobCode;

        private string companyEmail;

        private DateTime hireDate;
        #endregion

        #region Property

        public DateTime LastWorkingDate { get { return lastWorkingDate; } set { lastWorkingDate = value; } }

        public DateTime StartWorkingDate { get { return startWorkingDate; } set { startWorkingDate = value; } }

        public DateTime HireDate { get { return hireDate; } set { hireDate = value; } }

        public string Domain { get { return domain; } set { domain = value; } }

        public string Team { get { return team; } set { team = value; } }

        public string JobTitle { get { return jobTitle; } set { jobTitle = value; } }

        public string JobCode { get { return jobCode; }  set { jobCode = value; } }

        public string CompanyEmail { get { return companyEmail; } set { companyEmail = value; } }

        public int WorkExperience { get { return workExperience; } set { workExperience = value; } }

        public string EmploymentType { get { return employmentType; } set { employmentType = value; } }

        #endregion

        public override void GetTermination()
        {

            // delete the one from the excel who call this funtaion.

            // and write all these informaion to Termination sheet
            
        }

    }

    // Employee id is total of seven, one char means employee type, rest of them is number
    // eg.T000001
    public class EmployeeId : IEquatable<EmployeeId>
    {
        private readonly int number;
        private readonly char prefix;
        public EmployeeId(string id)
        {


            //Contains static methods for representing program contracts such as preconditions, 
            //postconditions, and object invariants.
            //Specifies a precondition contract for the enclosing method or property, 
            //and throws an exception if the condition for the contract fails.
            Contract.Requires<ArgumentNullException>(id != null);

            prefix = (id.ToUpper())[0];

            Contract.Requires<ArgumentNullException>(id.Length != 7);

            try
            {
                number = int.Parse(id.Substring(1, id.Length - 1));
            } 
            catch(FormatException)
            {
                throw new EmployeeIdExcetion("Invalid Emplyee Id format");
            }
        }
       
        public override string ToString()
        {
            return prefix.ToString() + string.Format("(0,6:000000)", number);
        }

        public bool Equals(EmployeeId other)
        {
            if (other == null)
                return false;
            return (prefix == other.prefix && number == other.number);
        }

        #region overwrite operator
        public static bool operator == (EmployeeId left, EmployeeId right)
        {
            return left.Equals(right);
        }
        public static bool operator != (EmployeeId left, EmployeeId right)
        {
            return !(left == right);
        }
        #endregion
    }
}
