using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry
{
    public partial class Contact
    {
        private Phone phone;
        private Email email;
        private Address address;
        private string firstName;
        private string lastName;

        public Contact()
        {
            phone = new Phone();
            email = new Email();
            address = new Address();
        }

        public Contact(Phone phone, Email email, Address address, string firstName, string lastName)
        {
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public Contact(Contact other)
        {
            this.phone = other.phone;
            this.email = other.email;
            this.address = other.address;
            this.firstName = other.firstName;
            this.lastName = other.lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set { if (!string.IsNullOrEmpty(value))
                    firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    lastName = value;
            }
        }

        public Phone Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Email Email
        {
            get { return email; }
            set { email = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
        public bool Validate()
        {
                bool adrOk = address.Validate();
                bool nameOk = (!string.IsNullOrEmpty(firstName)) && (!string.IsNullOrEmpty(lastName));
                return adrOk && nameOk;
        }
        public override string ToString()
        {
            return String.Format("{0,5} {1,10} {2,20} {3,30}",
                lastName, firstName, phone.CellPhone, email.WorkEmail);
        }
    }
}
