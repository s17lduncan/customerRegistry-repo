using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry
{
    public class Phone
    {
        private string cellPhone;
        private string homePhone;

        public Phone() { }

        public Phone(string cellPhone, string homePhone)
        {
            this.cellPhone = cellPhone;
            this.homePhone = homePhone;
        }

        public Phone(string cellPhone):this(cellPhone, string.Empty)
        {

        }

        public Phone(Phone other)
        {
            this.cellPhone = other.cellPhone;
            this.homePhone = other.homePhone;
        }

        public string HomePhone
        {
            get { return homePhone; }
            set { if(!string.IsNullOrEmpty(value))
                    homePhone = value; }
        }
        public string CellPhone
        {
            get { return cellPhone; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    cellPhone = value;
            }
        }

        public override string ToString()
        {
            string strOut = "\n" + "Phone Numbers" + "\n";

            strOut += string.Format(" {0,-10} {1, -10}\n", "Private", cellPhone);
            strOut += string.Format(" {0,-10} {1, -10}\n\n", "Office", homePhone);

            return strOut;
        }
    }
}
