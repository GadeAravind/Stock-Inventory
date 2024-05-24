import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isLoggedIn: boolean = false;
  isRedirected: boolean = false; 
  title: any;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn;
    if (this.isLoggedIn && !this.isRedirected) {
      this.router.navigate(['/dashboard']); 
      this.isRedirected = true;
    }

 
    this.authService.loginEvent.subscribe((isLoggedIn: boolean) => {
      this.isLoggedIn = isLoggedIn;
      if (isLoggedIn && !this.isRedirected) {
        this.router.navigate(['/']); 
        this.isRedirected = true;
      }
    });
  }

  logout() {
    this.authService.setLoggedIn(false, '');
    this.router.navigate(['/login']); 
    this.isRedirected = false; 
  }
}

