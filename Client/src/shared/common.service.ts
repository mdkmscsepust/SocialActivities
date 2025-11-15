import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DropdownOption } from './dropdown';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  constructor(private httpClient: HttpClient) { }
  getCategories() {
    return this.httpClient.get<DropdownOption[]>('http://localhost:5088/api/category/dropdown');
  }
}
