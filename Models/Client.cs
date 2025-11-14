using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        
        public Client()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            ContactNumber = string.Empty;
            Address = string.Empty;
        }

        
        public Client(int id, string firstName, string lastName, string contactNumber, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Address = address;
        }

       
        public string FullName => $"{FirstName} {LastName}";
    }
}
