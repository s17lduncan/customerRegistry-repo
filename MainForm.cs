using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRegistry
{
    public partial class MainForm : Form
    {
        CustomManager customManager;
        public MainForm()
        {
            InitializeComponent();
            InitializeGui();
        }

        private void InitializeGui()
        {
            customManager = new CustomManager();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            ContactForm contactForm = new ContactForm();
            contactForm.Text = "Add Customer";
            DialogResult frmResult = contactForm.ShowDialog();

            int id = 0;

            for(int i = 0; i < customManager.GetCustomerInfoString().Length; i++)
            {
                id = i + 1;
            }

            customManager.AddCustomer(id, contactForm.ContactData);

            if (frmResult == DialogResult.OK)
            {
                MessageBox.Show("Customer Added!");
                UpdateCustomerList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = lstCustomers.SelectedIndex;

            Customer customer = customManager.GetCustomer(index);

            //string email = customManager.GetEmailInfo(index);
            //string phone = customManager.GetPhoneInfo(index);
            //string address = customManager.GetAddressInfo(index);

            string title = "Edit Customer";
            ContactForm contactForm = new ContactForm(title, customer.Contact);
            DialogResult frmResult = contactForm.ShowDialog();

            if(customer != null && frmResult == DialogResult.OK)
            {
                customManager.ChangeCustomer(customer.Contact, index);
                UpdateCustomerList();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int index = lstCustomers.SelectedIndex;

            if (index < 0)
                return;

            customManager.DeleteCustomer(index);
            UpdateCustomerList();

        }

        private void UpdateCustomerList()
        {
            lstCustomers.Items.Clear();

            string[] strCustomers = customManager.GetCustomerInfoString();

            for (int i = 0; i < strCustomers.Length; i++)
            {
                string str = strCustomers[i];
                lstCustomers.Items.Add(str);
            }

        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstCustomers.SelectedIndex;

            if(index >= 0)
            {
                Customer customer = customManager.GetCustomer(index);
                string str = customer.GetCustomerInfoToString();
                lblCustomerInfo.Text = customer.GetCustomerInfoToString();
                lblCustomerName.Text = customer.Contact.FirstName + " " + customer.Contact.LastName;
            }
            
            
        }
    }
}
