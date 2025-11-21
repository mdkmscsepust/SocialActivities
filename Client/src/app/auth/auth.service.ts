import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Login, LoginResponse } from './models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  login(login: Login): Observable<LoginResponse> {
    return this.httpClient
    .post<LoginResponse>('http://localhost:5182/api/users/login', login)
    .pipe(
      map(response=> ({
        accessToken: response.accessToken
      }))
    );
  }

  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  register(username: string, password: string) {
    return this.httpClient.post('/api/auth/register', { username, password });
  }

}
