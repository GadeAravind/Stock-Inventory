import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AuthService } from 'src/app/services/auth.service';
 
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  formSubmitted = false;
 
  constructor(private http: HttpClient, private router: Router, private authService: AuthService, private formBuilder: FormBuilder) {
    this.registerForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    });
  }
 
  ngOnInit(): void {
  }
 
  register() {
    this.formSubmitted = true;
    if (this.registerForm.valid) {
      let registerData = {
        userId:'',
        fullName: this.registerForm.get('fullName')?.value,
        email: this.registerForm.get('email')?.value,
        password: this.registerForm.get('password')?.value,
        confirmPassword: this.registerForm.get('confirmPassword')?.value
      };
 
      this.http.post("http://localhost:5240/Registration", registerData).subscribe((res: any) => {
        if (res.result) {
          alert("Registration Successful");
          this.router.navigate(['/login']);
        } else {
          alert(res.message);
        }
      });
    }
  }
}
 