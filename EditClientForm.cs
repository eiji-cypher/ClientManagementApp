using ClientManagementApp.Models;
using System;
using System.Windows.Forms;

namespace ClientManagementApp
{
    public partial class EditClientForm : Form
    {
        public Client UpdatedClient { get; private set; }
        private Client originalClient;

        public EditClientForm(Client client)
        {
            InitializeComponent();
            originalClient = client;
            LoadClientData();
        }

        private void LoadClientData()
        {
            txtFirstName.Text = originalClient.FirstName;
            txtLastName.Text = originalClient.LastName;
            txtContactNumber.Text = originalClient.ContactNumber;
            txtAddress.Text = originalClient.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("First name is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Last name is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    MessageBox.Show("Contact number is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactNumber.Focus();
                    return;
                }

                if (!IsValidContactNumber(txtContactNumber.Text.Trim()))
                {
                    MessageBox.Show("Contact number can only contain numbers, spaces, hyphens, and plus sign (+).",
                        "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactNumber.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Address is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                UpdatedClient = new Client
                {
                    Id = originalClient.Id, 
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    ContactNumber = txtContactNumber.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating client: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidContactNumber(string contactNumber)
        {
            try
            {
                foreach (char c in contactNumber)
                {
                    if (!char.IsDigit(c) && c != ' ' && c != '-' && c != '+' && c != '(' && c != ')')
                    {
                        return false;
                    }
                }

                bool hasDigit = false;
                foreach (char c in contactNumber)
                {
                    if (char.IsDigit(c))
                    {
                        hasDigit = true;
                        break;
                    }
                }

                return hasDigit;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditClientForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}