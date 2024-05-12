using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRegistry
{
    public partial class ContactForm : Form
    {
        Contact currentContact;
        private bool closeForm;
        public ContactForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        public ContactForm(string title, Contact contact)
        {
            InitializeComponent();
            InitializeEdit(title, contact);
        }

        private void InitializeEdit(string title, Contact contact)
        {
            this.Text = title;

            txtWorkEmail.Text = contact.Email.WorkEmail;
            txtPrivateEmail.Text = contact.Email.PersonalEmail;

            txtHomePhone.Text = contact.Phone.HomePhone;
            txtCellPhone.Text = contact.Phone.CellPhone;

            txtZip.Text = contact.Address.Zipcode;
            txtCity.Text = contact.Address.City;
            txtStreet.Text = contact.Address.Street;

            cmbCountry.DataSource = Enum.GetValues(typeof(Countries));
            contact.Address.Country = (Countries)cmbCountry.SelectedIndex;


            txtFirstName.Text = contact.FirstName;
            txtLastName.Text = contact.LastName;

            currentContact = contact;
        }

        private void InitializeGUI()
        {
             
            currentContact = new Contact();
            cmbCountry.DataSource = Enum.GetValues(typeof(Countries));

            btnOk.DialogResult = DialogResult.OK;

        }

        public Contact ContactData
        {
            get { return currentContact;  }
            set
            {
                currentContact = value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            ReadAddress();
            ReadEmails();
            ReadPhones();
            ReadNames();

            UpdateGUI();

        }



        private void ReadAddress()
        {
            Address address = new Address();

            address.Street = txtStreet.Text;
            address.City = txtCity.Text;
            address.Zipcode = txtZip.Text;
            address.Country = (Countries)cmbCountry.SelectedIndex;

            currentContact.Address = address;
        }

        private void ReadEmails()
        {
            Email email = new Email();

            email.PersonalEmail = txtPrivateEmail.Text;
            email.WorkEmail = txtWorkEmail.Text;

            currentContact.Email = email;
        }

        private void ReadNames()
        {

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;

            if(firstName != string.Empty && lastName != string.Empty)
            {
                currentContact.FirstName = firstName;
                currentContact.LastName = lastName;
            }

        }

        private void ReadPhones()
        {
            Phone phone = new Phone();

            phone.HomePhone = txtHomePhone.Text;
            phone.CellPhone = txtCellPhone.Text;

            currentContact.Phone = phone;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        public void ContactForm_FormClosed(Object sender, FormClosingEventArgs e)
        {
            Customer customer = new Customer();

            customer.Contact = currentContact;

            MessageBox.Show(customer.ToString());
        }

        private void UpdateGUI()
        {
            this.Close();
        }


    }
}
