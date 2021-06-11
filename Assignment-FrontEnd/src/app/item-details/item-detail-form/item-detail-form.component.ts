import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ItemDetail } from 'src/app/shared/item-detail.model';
import { ItemDetailService } from 'src/app/shared/item-detail.service';

@Component({
  selector: 'item-detail-form',
  templateUrl: './item-detail-form.component.html',
  styles: [
  ]
})
export class ItemDetailFormComponent implements OnInit {

  constructor(public _itemService: ItemDetailService,
    private toastr : ToastrService) { }

  ngOnInit(): void {
  }

  insertOrUpdateItem(itemForm : NgForm){

    if(this._itemService.formData.itemId == 0){
      this.insertItem(itemForm);
    }
    else{
      this.updateItem(itemForm);
    }
    
  }

  insertItem(itemForm : NgForm){
    this._itemService.submitItem().subscribe(
      response => {
        this._itemService.getItemsList();
        this.resetForm(itemForm);
        if(response){
          this.toastr.success('Item Submitted Successfully','Item Submit Success');
        }
        else{
          this.toastr.error('Item Not Submitted Successfully. Please try again later.','Submit Error')
        }
        
      },
      err => {
        console.log(err);
      });
  }

  updateItem(itemForm : NgForm){
    this._itemService.updateItem().subscribe(
      response => {
        this._itemService.getItemsList();
        this.resetForm(itemForm);
        if(response){
          this.toastr.info('Item Updated Successfully','Item Update Success');
        }
        else{
          this.toastr.error('Error in Updating an Item. Please try again later.','Update Item Error')
        }
        
      },
      err => {
        console.log(err);
      });
  }

  resetForm(itemform : NgForm){
    itemform.form.reset();
    this._itemService.formData = new ItemDetail
  }
}
