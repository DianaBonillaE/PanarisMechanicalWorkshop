using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
    public class Client
    {
        int idClient;
        String clientName;
        String lastName;
        String phoneNumber;
        String address;
        String email;

        public Client(int idClient, string clientName, string lastName, string phoneNumber, string address, string email)
        {
            this.IdClient = idClient;
            this.ClientName = clientName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Email = email;
        }

        public Client()
        {
        }

        public int IdClient { get => idClient; set => idClient = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
    }
}
