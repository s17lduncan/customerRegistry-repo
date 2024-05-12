using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRegistry
{
    internal class CustomManager
    {
        private List<Customer> customers;

        public CustomManager()
        {
            customers = new List<Customer>();
        }

        public Customer GetCustomer(int index)
        {
            if (CheckIndex(index))
                return customers[index];
            else
                return null;
        }

        public bool AddCustomer(int id, Contact currentContact)
        {
            if (currentContact == null)
                return false;

            Customer customer = new Customer(id, currentContact);
            customers.Add(customer);

            return true;
        }

        public void ChangeCustomer(Contact contact, int index)
        {

            if (CheckIndex(index) && contact != null)
            {
                customers[index] = new Customer(index, contact);
            }

        }

        public string[] GetCustomerInfoString()
        {
            string[] customerInfo = new string[customers.Count];

            int i = 0;

            foreach (Customer customerObj in customers) 
            {
                customerInfo[i++] = customerObj.ToString();
            }

            return customerInfo;
        }

        //The Following Three Functions Were Not Needed, but were within the Assignment Document
        public string GetEmailInfo(int index)
        {
            string str = "";

            if (CheckIndex(index))
            {
                str = customers[index].Contact.Email.ToString();
            }
            return str;
        }
        public string GetPhoneInfo(int index)
        {
            string str = "";

            if (CheckIndex(index))
            {
                str = customers[index].Contact.Phone.ToString();
            }
            return str;
        }
        public string GetAddressInfo(int index)
        {
            string str = "";

            if (CheckIndex(index))
            {
                str = customers[index].Contact.Address.ToString();
            }
            return str;
        }

        public void DeleteCustomer(int index)
        {
            if(CheckIndex(index))
                customers.RemoveAt(index);
        }

        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < customers.Count);
        } 
    }
}
