import { Injectable } from '@angular/core';
import { ItemDetail } from './item-detail.model';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from './Constants/EndpointConst'

@Injectable({
  providedIn: 'root'
})
export class ItemDetailService {

  constructor(private _http: HttpClient) { }

  formData: ItemDetail = new ItemDetail();
  itemslist : ItemDetail[] = [];
  
  //API request for submitting an item.
  submitItem(){
    return this._http.post(BASE_URL,this.formData);
  }

  //API request for fetching the list of items.
  getItemsList(){
    this._http.get(BASE_URL)
    .toPromise()
    .then( response => this.itemslist = response as ItemDetail[]);
  }

  //API request for updating an existing item.
  updateItem(){
    return this._http.put(`${BASE_URL}/${this.formData.itemId}`,this.formData);
  }

  //API request for updating an existing item.
  deleteItem(id: number){
    return this._http.delete(`${BASE_URL}/${id}`);
  }
}
