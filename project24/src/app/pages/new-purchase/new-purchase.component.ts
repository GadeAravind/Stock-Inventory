import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service'; 
import { ApiResponse } from 'src/app/models/api-response';

@Component({
  selector: 'app-new-purchase',
  templateUrl: './new-purchase.component.html',
  styleUrls: ['./new-purchase.component.css']
})
export class NewPurchaseComponent {

  purchaseObj: any = {
    "purchaseId": 0,
    "purchaseDate": "2023-09-23T11:00:36.277Z",
    "productId": 0,
    "quantity": 0,
    "supplierName": "",
    "invoiceAmount": 0,
    "invoiceNumber": ""
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

  onSave() {
    const token = this.authService.getToken();
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    this.http.post<ApiResponse<any>>('http://localhost:5240/StockInventory/PurchaseCreation', this.purchaseObj, { headers }).subscribe(
      (res) => {
        if (res.result) {
          alert("Purchase Done Success");
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
