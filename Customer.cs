using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry
{
    internal class Customer
    {
        private Contact contact;
        private int id;

        public Customer()
        {
            contact = new Contact();
        }

        public Customer(int id, Contact contact)
        {
            this.contact = contact;
            this.id = id;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Contact Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public string GetCustomerInfoToString()
        {
            string strPhone = contact.Phone.ToString();
            string strEmail = contact.Email.ToString();
            string strAddress = contact.Address.ToString();

            return String.Format("{0,5} {1,5} {2,5}",
            strPhone, strEmail, strAddress);

        }

        public override string ToString()
        {
            string idStr = "00" + id.ToString();
            string contactStr = contact.ToString();

            return String.Format("{0,5} {1,5}",idStr, contactStr);
        }


    }
}
