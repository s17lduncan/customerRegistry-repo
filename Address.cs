using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry
{
    public class Address
    {
        private string street;
        private string city;
        private string zipcode;

        private Countries country;
        public Address() { }

        public Address(string street, string city, string zipcode, Countries country)
        {
            this.street = street;
            this.city = city;
            this.zipcode = zipcode;
            this.country = country;
        }

        public Address(Address other)
        {
            this.street = other.street;
            this.city = other.city;
            this.zipcode = other.zipcode;
            this.country = other.country;
        }

        public string Street
        {
            get { return street; }
            set { if (!string.IsNullOrEmpty(value)) 
                    street = value; }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    city = value;
            }
        }

        public string Zipcode
        {
            get { return zipcode; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    zipcode = value;
            }
        }

        public Countries Country
        {
            get { return country; }
            set { country = value; }
        }

        public bool Validate()
        {
            bool ok = false;

            if (!string.IsNullOrEmpty(city))
                ok = true;

            return ok;
        }

        public string GetAddressLabel()
        {
            string addressLabel = ToString();

            return addressLabel;
        }

        public string countryToString()
        {
            string countryStr = country.ToString();
            countryStr = countryStr.Replace("_", " ");
            return countryStr;
        }

        public override string ToString()
        {
            string countryString = countryToString();

            string strOut = "\n" + "Address" + "\n";

            strOut += string.Format(" {0,-10} {1, -10}\n", "Street", street);
            strOut += string.Format(" {0,-10} {1, -10}\n\n", "City", city);
            strOut += string.Format(" {0,-10} {1, -10}\n\n\n", "Zipcode", zipcode);
            strOut += string.Format(" {0,-10} {1, -10}\n\n\n\n", "Country", countryString);

            return strOut;
        }


    }
}
