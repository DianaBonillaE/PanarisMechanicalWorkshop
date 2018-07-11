using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
    public class WorkDetail
    {
        int idWorkDetail;
        float price;
        String description;
        WorkOrder workOrder;

        public int IdWorkDetail { get => idWorkDetail; set => idWorkDetail = value; }
        public float Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public WorkOrder WorkOrder { get => workOrder; set => workOrder = value; }

        public WorkDetail(int idWorkDetail, float price, string description, WorkOrder workOrder)
        {
            this.IdWorkDetail = idWorkDetail;
            this.Price = price;
            this.Description = description;
            this.WorkOrder = workOrder;
        }

        public WorkDetail()
        {
            WorkOrder = new WorkOrder();
        }
    }
}
