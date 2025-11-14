using ClientManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClientManagementApp
{
    public partial class Form1 : Form
    {
        private List<Client> clients;
        private ClientDataService dataService;

        public Form1()
        {
            InitializeComponent();
            dataService = new ClientDataService();
            clients = new List<Client>();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            SetupDataGridView();
        }

        
        private void SetupDataGridView()
        {
            dgvClients.AutoGenerateColumns = false;
            dgvClients.Columns.Clear();

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25 
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ContactNumber",
                HeaderText = "Contact No.",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Address",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25
            });
        }

       
        private void LoadData()
        {
            clients = dataService.LoadClients();
            RefreshDataGridView();
        }

       
        private void RefreshDataGridView()
        {
            dgvClients.DataSource = null;
            dgvClients.DataSource = clients;
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddClientForm addForm = new AddClientForm(dataService.GetNextId(clients));

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    clients.Add((Client)GetNewClient(addForm));
                    RefreshDataGridView();
                    MessageBox.Show("Client added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding client: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static object GetNewClient(AddClientForm addForm)
        {
            return addForm.NewClient;
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dgvClients.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a client to edit.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvClients.SelectedRows.Count == 0 || dgvClients.CurrentRow == null)
                { 
                    MessageBox.Show("Please select a client to edit.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                int rowIndex = dgvClients.CurrentRow.Index;

                if (rowIndex < 0 || rowIndex >= clients.Count)
                {
                    MessageBox.Show("Invalid row selected. Please try again.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Client selectedClient = clients[rowIndex];

                EditClientForm editForm = new EditClientForm(selectedClient);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    clients[rowIndex] = editForm.UpdatedClient;
                    RefreshDataGridView();
                    MessageBox.Show("Client updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing client: {ex.Message}\n\nDetails: {ex.StackTrace}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dgvClients.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a client to delete.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                Client selectedClient = (Client)dgvClients.SelectedRows[0].DataBoundItem;

                
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete {selectedClient.FullName}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    
                    clients.Remove(selectedClient);

                    
                    ReassignClientIds();

                    
                    RefreshDataGridView();

                    MessageBox.Show("Client deleted successfully! IDs have been updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting client: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void ReassignClientIds()
        {
            try
            {
                int newId = 1;
                foreach (var client in clients)
                {
                    client.Id = newId;
                    newId++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reassigning IDs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool saved = dataService.SaveClients(clients);
                if (!saved)
                {
                    DialogResult result = MessageBox.Show(
                        "Failed to save data. Do you still want to close?",
                        "Save Error",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during shutdown: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}