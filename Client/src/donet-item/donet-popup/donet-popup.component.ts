import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DonetItemCreate } from './donet-item-create';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonService } from '../../shared/common.service';
import { DropdownOption } from '../../shared/dropdown';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-donet-popup',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './donet-popup.component.html',
  styleUrl: './donet-popup.component.css'
})
export class DonetPopupComponent implements OnInit {
  categories: DropdownOption[] = [];
  @Output() close = new EventEmitter<void>();
  @Output() submitItem = new EventEmitter<DonetItemCreate>();

  donationForm: FormGroup;

  constructor(private fb: FormBuilder, private commonService: CommonService) {
    this.donationForm = this.fb.group({
      tag: ['', Validators.required],
      title: ['', Validators.required],
      description: ['', Validators.required],
      location: ['', Validators.required],
      categoryId: [0, [Validators.required, Validators.min(1)]]
    });
  }
  ngOnInit(): void {
    this.commonService.getCategories().subscribe(categories => {
      this.categories = categories;
    });
  }

  onClose() {
    this.close.emit();
  }

  onSubmit() {
    if (this.donationForm.valid) {
      this.submitItem.emit(this.donationForm.value);
      this.onClose();
      this.donationForm.reset({ categoryId: 0 });
    }
  }
}
