using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    class Person
    {
        public Person()
        {
            //
        }
        #region Person Information
        private string name;

        private string id;

        private DateTime birthday;

        private string sex;

        #endregion
       

        public string Name { get { return name; } set { name = value; } }

        public DateTime Brithday { get { return birthday; } set { birthday = value; } }

        public string ID { get { return id; } set { id = value; } }

        
        public virtual bool GetTermination()
        {
            return false;
        }

    }
}
