import { WorkDetail } from "./workDetail.model";

export class Product {

    idProduct: number;
    name: String;
    quantity: number;
    order: boolean;
    price: number;
    workDetail: WorkDetail=new WorkDetail();


}