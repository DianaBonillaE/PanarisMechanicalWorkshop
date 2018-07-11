import { WorkOrder } from "./workOrder.model";

export class WorkDetail {

    idWorkDetail: number;
    price: number;
    description: String;
    workOrder: WorkOrder=new WorkOrder();
}