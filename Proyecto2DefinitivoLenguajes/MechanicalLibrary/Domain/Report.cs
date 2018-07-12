using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
    public class Report
    {
        IList<VehicleDetail> vehicleDetailList;
        WorkOrder workOrder;
        IList<WorkDetail> workDetailList;
        IList<Product> productList;


        public Report()
        {
            
            VehicleDetailList= new List<VehicleDetail>();
            WorkDetailList = new List<WorkDetail>();
            ProductList= new List<Product>();
            WorkOrder = new WorkOrder();

        }

        public IList<VehicleDetail> VehicleDetailList { get => vehicleDetailList; set => vehicleDetailList = value; }
        public WorkOrder WorkOrder { get => workOrder; set => workOrder = value; }
        public IList<WorkDetail> WorkDetailList { get => workDetailList; set => workDetailList = value; }
        public IList<Product> ProductList { get => productList; set => productList = value; }

        public Report( IList<VehicleDetail> vehicleDetailList, WorkOrder workOrder, IList<WorkDetail> workDetailList, IList<Product> productList)
        {
     
            this.vehicleDetailList = vehicleDetailList;
            this.workOrder = workOrder;
            this.workDetailList = workDetailList;
            this.productList = productList;
        }
    }

}
