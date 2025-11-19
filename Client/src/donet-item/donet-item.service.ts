import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DonetItem } from './donet-item';
import { Observable } from 'rxjs';
import { DonetItemCreate } from './donet-popup/donet-item-create';

@Injectable({
  providedIn: 'root'
})
export class DonetItemService {

  constructor(private httpClient: HttpClient) { }
  getDonetItems() : Observable<DonetItem[]> {
    return this.httpClient.get<DonetItem[]>('http://localhost:5001/api/post');
  }

  createDonetItem(item: DonetItemCreate) : Observable<any> {
    return this.httpClient.post<any>('http://localhost:5001/api/post', item);
  }

  toggleLiked(postid: number) : Observable<{'isLiked': boolean, 'likedCount': number}> {
    return this.httpClient.post<{'isLiked': boolean, 'likedCount': number}>(`http://localhost:5001/api/Like/toggle_liked/${postid}`, {});
  }
}
