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
                Clear();
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
        //Method to clear fields
        public void Clear()
        {
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtboxContactNo.Text = "";
            txtboxAddress.Text = "";
            cmbGender.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get data from the grid view and load it to the textboxes
            //Identify the row on which the mouse is clicked
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtboxContactNo.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }
    }
}
