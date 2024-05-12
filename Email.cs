using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry
{
    public class Email
    {
        private string personalEmail;
        private string workEmail;

        public Email() { }

        public Email(string workMail, string personalMail)
        {
            this.personalEmail = workMail;
            this.workEmail = personalMail;
        }


        public Email(string workMail):this(workMail, string.Empty)
        {

        }

        public Email(Email other)
        {
            this.personalEmail = other.personalEmail;
            this.workEmail = other.workEmail;
        }
        public string PersonalEmail
        {
            get { return personalEmail;  }
            set { if (!string.IsNullOrEmpty(value))
                    personalEmail = value;
            }
        }

        public string WorkEmail
        {
            get { return workEmail; }
            set { if(!string.IsNullOrEmpty(value))
                    workEmail = value;}
        }

        public string GetToStringItemsHeadings
        {
            get { return string.Format("{0,-20} {1, -20}", "Work EmailData", "Private EmailData"); }
        }

        public override string ToString()
        {
            string strOut = "\n" + "Emails" + "\n";

            strOut += string.Format(" {0,-10} {1, -10}\n", "Private", personalEmail);
            strOut += string.Format(" {0,-10} {1, -10}\n\n", "Office", workEmail);

            return strOut;
        }

    }
}
