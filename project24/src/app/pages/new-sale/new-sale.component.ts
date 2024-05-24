import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service'; 
import { ApiResponse } from 'src/app/models/api-response';

@Component({
  selector: 'app-new-sale',
  templateUrl: './new-sale.component.html',
  styleUrls: ['./new-sale.component.css']
})
export class NewSaleComponent {
  saleObj: any = {
    "saleId": 0,
    "invoiceNumber": "",
    "customerName": "",
    "mobileNo": "",
    "saleDate": "2023-09-23T11:19:38.047Z",
    "productId": 0,
    "quantity": 0,
    "totalAmount": 0
  };
  productList: any[] = [];

  constructor(private http: HttpClient, private authService: AuthService) {}

  ngOnInit(): void {
    this.getAllProduct();
  }

  getAllProduct() {
    const token = this.authService.getToken();
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    this.http.get<ApiResponse<any>>('http://localhost:5240/StockInventory/ListOfProducts', { headers }).subscribe(
      (res) => {
        this.productList = res.data;
      },
      (error) => {
        console.error('Error fetching products:', error);
      }
    );
  }

  checkStock() {
    const token = this.authService.getToken();
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });

    this.http.post<ApiResponse<any>>(`http://localhost:5240/StockInventory/CheckingStock`,this.saleObj.productId, { headers }).subscribe(
      (res) => {
        if (!res.result) {
          alert("Stock Not Available");
        }
      },
      (error) => {
        console.error('Error checking stock:', error);
      }
    );
  }

  onSave() {
    const token = this.authService.getToken();
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    this.http.post<ApiResponse<any>>('http://localhost:5240/StockInventory/SaleCreation', this.saleObj, { headers }).subscribe(
      (res) => {
        if (res.result) {
          alert("Sale Done Success");
        } else {
          alert(res.message);
        }
      },
      (error) => {
        console.error('API Error:', error);
        alert("API Error");
      }
    );
  }
}
