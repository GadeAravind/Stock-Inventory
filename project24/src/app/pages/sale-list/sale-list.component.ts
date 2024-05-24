import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service'; // Replace 'path-to-your-auth-service' with the actual path
import { ApiResponse } from 'src/app/models/api-response';

@Component({
  selector: 'app-sale-list',
  templateUrl: './sale-list.component.html',
  styleUrls: ['./sale-list.component.css']
})
export class SaleListComponent implements OnInit {
  saleList: any[] = [];

  constructor(private http: HttpClient, private authService: AuthService) {}

  ngOnInit(): void {
    this.loadSales();
  }

  loadSales() {
    const token = this.authService.getToken();
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    this.http.get<ApiResponse<any>>('http://localhost:5240/StockInventory/ListOfSale', { headers }).subscribe(
      (response) => {
        this.saleList = response.data;
      },
      (error) => {
        console.error('Error fetching sales:', error);
      }
    );
  }
}

