using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
   public class WorkOrder
    {
        int idWorkOrder;
        String description;
        DateTime deliveryDate;
        float totalPrice;
        Client client;
        Vehicle vehicle;

        public int IdWorkOrder { get => idWorkOrder; set => idWorkOrder = value; }
        public string Description { get => description; set => description = value; }
        public DateTime DeliveryDate { get => deliveryDate; set => deliveryDate = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public Client Client { get => client; set => client = value; }
        public Vehicle Vehicle { get => vehicle; set => vehicle = value; }

        public WorkOrder(int idWorkOrder, string description, DateTime deliveryDate, float totalPrice, Client client, Vehicle vehicle)
        {
            this.IdWorkOrder = idWorkOrder;
            this.Description = description;
            this.DeliveryDate = deliveryDate;
            this.TotalPrice = totalPrice;
            this.Client = client;
            this.Vehicle = vehicle;
        }

        public WorkOrder()
        {
            Client = new Client();
            Vehicle = new Vehicle();
        }
    }
}
