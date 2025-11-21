import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { LoginResponse } from '../models/login';

@Component({
  standalone: true,
  selector: 'app-login',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup; 
  constructor(private fb: FormBuilder,
    private authService: AuthService
  ) {
      this.loginForm = this.fb.group({
        username: ['', Validators.required],
        password: ['', Validators.required]
      });
  }


  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }
    this.authService.login(this.loginForm.value).subscribe({
      next: (response) => {
        this.authService.setToken(response.accessToken);
        console.log('Login successful:', response.accessToken);
      },
      error: (error) => {
        console.error('Login failed:', error);
      }
    });
    const loginData = this.loginForm.value;
    console.log('Login data submitted:', loginData);
  }
}
