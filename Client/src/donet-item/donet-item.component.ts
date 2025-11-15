import { Component, OnInit } from '@angular/core';
import { DonetItemService } from './donet-item.service';
import { DonetItem } from './donet-item';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TimeAgoPipe } from './time-ago.pipe';
import { DonetItemCreate } from './donet-popup/donet-item-create';
import { DonetPopupComponent } from './donet-popup/donet-popup.component';

@Component({
  selector: 'app-donet-item',
  standalone: true,
  imports: [FormsModule, CommonModule, TimeAgoPipe, DonetPopupComponent],
  templateUrl: './donet-item.component.html',
  styleUrl: './donet-item.component.css'
})
export class DonetItemComponent implements OnInit {
  showPopup: boolean = false;
  donetItems: DonetItem[] = [];
  public constructor(private donetitemService: DonetItemService) { }
  ngOnInit() {
    this.donetitemService.getDonetItems().subscribe(items => {
      this.donetItems = items;
      console.log(this.donetItems);
    });
  }

  openPopup() {
    this.showPopup = true;
  }

  closePopup() {
    this.showPopup = false;
  }

  handleSubmit(item: DonetItemCreate) {
    this.donetitemService.createDonetItem(item).subscribe(res => {
      console.log('Created:', res);
    });
  }

}
