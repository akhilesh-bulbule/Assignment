import { Component, OnInit } from '@angular/core';
import { ItemDetail } from '../shared/item-detail.model';
import { ItemDetailService } from '../shared/item-detail.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'item-details',
  templateUrl: './item-details.component.html',
  styles: [
  ]
})
export class ItemDetailsComponent implements OnInit {

  constructor(public _itemService: ItemDetailService,
    private toastr : ToastrService) { }

  ngOnInit(): void {
      this.getItemsList();
  }

  getItemsList(){
    this._itemService.getItemsList();
  }

  editItem(item: ItemDetail){
    this._itemService.formData = Object.assign({},item);
  }

  getTotalAmount(itemPrice : number, itemQuantity: number){
    return itemPrice * itemQuantity;
  }

  deleteCurrentItem(itemId : number){
    this._itemService.deleteItem(itemId).subscribe(response => {
      if(response){
        this.toastr.success('Item Deleted Successfully','Item Delete Success');
        this.getItemsList();
      }
      else{
        this.toastr.error('Error in deleting an item. Please try again later.','Delete Error')
      }
    })
  }
}
