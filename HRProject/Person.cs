using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    public class Person
    {
        public Person()
        {
            //
        }

        #region Person Information
        private string name;

        private string id;

        private DateTime birthday;

        private string gender;

        private string city;

        private string accountName;

        private string bankAccount;

        private string formlyCompany;

        private string email;
        #endregion
       

        public string Name { get { return name; } set { name = value; } }

        public DateTime Brithday { get { return birthday; } set { birthday = value; } }

        public string ID { get { return id; } set { id = value; } }

        public string Gender { get { return gender; } set { gender = value; } }

        public string City { get { return city; } set { city = value; } }

        public string BankAccount { get { return bankAccount; } set { bankAccount = value; } }

        public string AccountName { get { return accountName; } set { accountName = value; } }

        public string FormlyCompany { get { return formlyCompany; } set { formlyCompany = value; } }

        public string Email { get { return email; } set { email = value; } }



        public virtual void GetTermination()
        {
           
        }

    }
}
