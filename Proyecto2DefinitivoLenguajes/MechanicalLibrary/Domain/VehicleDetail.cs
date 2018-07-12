using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
   public class VehicleDetail
    {
        int idVehicleDetail;
        int quantity;
        String observations;
        WorkOrder workOrder;
        TypeDetail typeDetail;
        Condition condition;

        public int IdVehicleDetail { get => idVehicleDetail; set => idVehicleDetail = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Observations { get => observations; set => observations = value; }
        public WorkOrder WorkOrder { get => workOrder; set => workOrder = value; }
        public TypeDetail TypeDetail { get => typeDetail; set => typeDetail = value; }
        public Condition Condition { get => condition; set => condition = value; }

        public VehicleDetail(int idVehicleDetail, int quantity, string observations, WorkOrder workOrder, TypeDetail typeDetail, Condition condition)
        {
            this.IdVehicleDetail = idVehicleDetail;
            this.Quantity = quantity;
            this.Observations = observations;
            this.WorkOrder = workOrder;
            this.TypeDetail = typeDetail;
            this.Condition = condition;
        }

        public VehicleDetail()
        {
            WorkOrder = new WorkOrder();
            TypeDetail = new TypeDetail();
            Condition = new Condition();
        }

    }
}
