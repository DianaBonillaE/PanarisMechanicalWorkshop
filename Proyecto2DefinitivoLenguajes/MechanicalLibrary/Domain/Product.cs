using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
   public class Product
    {
        int idProduct;
        String name;
        int quantity;
        Boolean order;
        float price;
        WorkDetail workDetail;

        public int IdProduct { get => idProduct; set => idProduct = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public bool Order { get => order; set => order = value; }
        public float Price { get => price; set => price = value; }
        public WorkDetail WorkDetail { get => workDetail; set => workDetail = value; }

        public Product(int idProduct, string name, int quantity, bool order, float price, WorkDetail workDetail)
        {
            this.IdProduct = idProduct;
            this.Name = name;
            this.Quantity = quantity;
            this.Order = order;
            this.Price = price;
            this.WorkDetail = workDetail;
        }

        public Product()
        {
            WorkDetail = new WorkDetail();
        }
    }
}
