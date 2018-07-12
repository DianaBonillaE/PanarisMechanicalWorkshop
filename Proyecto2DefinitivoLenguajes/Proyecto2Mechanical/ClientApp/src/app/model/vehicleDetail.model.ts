import { WorkOrder } from "./workOrder.model";
import { TypeDetail } from "./typeDetail.model";
import { Condition } from "./condition.model";

export class VehicleDetail {

    idVehicleDetail: string;
    quantity: string;
    observations: string;
    workOrder: WorkOrder = new WorkOrder();
    typeDetail: TypeDetail = new TypeDetail();;
    condition: Condition = new Condition();

}
