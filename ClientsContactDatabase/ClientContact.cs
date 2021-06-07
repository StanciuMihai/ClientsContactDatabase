using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientsContactDatabase
{
    public partial class ClientContact : Form
    {
        public ClientContact()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the values from the input fields
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtboxContactNo.Text;
            c.Address = txtboxAddress.Text;
            c.Gender = cmbGender.Text;
            //Insert data
            bool success = c.Insert(c);
            if(success==true)
            {
                //Successfully inserted
                MessageBox.Show("New contact successfully inserted!");
            }
            else
            {
                //Failed to add contact
                MessageBox.Show("Failed to add new contact. Try again!");
            }
            //Load data to GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void ClientContact_Load(object sender, EventArgs e)
        {
            //Load data to GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }
    }
}
