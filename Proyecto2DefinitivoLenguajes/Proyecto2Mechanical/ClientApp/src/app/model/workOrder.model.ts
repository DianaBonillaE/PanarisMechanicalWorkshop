import { Client } from "./client.model";
import { Vehicle } from "./vehicle.model";

export class WorkOrder{

    idWorkOrder:number;
    description:String;
    deliveryDate:DateTimeFormat;
    totalPrice:number;
    client:Client=new Client();
    vehicle:Vehicle=new Vehicle();  
}
