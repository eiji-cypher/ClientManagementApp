using ClientManagementApp;
using ClientManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace ClientManagementApp
{
    public class ClientDataService
    {
        private readonly string _filePath;

        public ClientDataService()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _filePath = Path.Combine(appDirectory, "clients.json");
        }

        public List<Client> LoadClients()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonData = File.ReadAllText(_filePath);

                    var clients = JsonSerializer.Deserialize<List<Client>>(jsonData);
                    return clients ?? new List<Client>();
                }
                else
                {
                    // For debuggingggg
                    System.Windows.Forms.MessageBox.Show(
                        "No saved data found. Starting with empty list.",
                        "No Data File",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(
                    $"Error loading data: {ex.Message}",
                    "Load Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }

            return new List<Client>();
        }

        public bool SaveClients(List<Client> clients)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true 
                };

                string jsonData = JsonSerializer.Serialize(clients, options);
                File.WriteAllText(_filePath, jsonData);


                System.Windows.Forms.MessageBox.Show(
                    $"Data saved successfully!\nLocation: {_filePath}\nClients saved: {clients.Count}",
                    "Save Success",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Error saving data: {ex.Message}",
                    "Save Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public int GetNextId(List<Client> clients)
        {
            if (clients.Count == 0)
                return 1;

            int maxId = 0;
            foreach (var client in clients)
            {
                if (client.Id > maxId)
                    maxId = client.Id;
            }
            return maxId + 1;
        }
    }
}