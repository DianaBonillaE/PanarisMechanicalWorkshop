import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../model/product.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProductService {

  baseUrl: String;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public insertProduct(product: Product) {
    return this.http.post(this.baseUrl + 'api/product', product);
  }

  public getAllProductByIdWorkDetail(id:number):Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl+'api/product/'+id);
  }

}
