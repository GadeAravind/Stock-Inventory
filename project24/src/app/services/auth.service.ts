import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn: boolean = false;
  tokenKey: string = 'auth_token'; 

  loginEvent: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private http: HttpClient) {
    
    this.isLoggedIn = !!localStorage.getItem(this.tokenKey);
  }

  setLoggedIn(value: boolean, token: string | null) {
    this.isLoggedIn = value;
    if (value && token) {
      localStorage.setItem(this.tokenKey, token); 
    } else {
      localStorage.removeItem(this.tokenKey); 
    }
    this.loginEvent.emit(this.isLoggedIn);
  }
  
  getToken(): string {
    return localStorage.getItem(this.tokenKey)??'';
  }

}
