import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiResponse } from 'src/app/models/api-response';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent {

  productObj: any = {
    "productId": 0,
    "productName": "",
    "categoryName": "",
    "createdDate": "2024-04-25T15:19:27.194Z",
    "price": 0,
    "productDetails": ""
  };
  productList: any[] = [];

  constructor(private http: HttpClient, private authService: AuthService) {}

  ngOnInit(): void {
    
  }
  onSave() {
    const token = this.authService.getToken();
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    this.http.post<ApiResponse<any>>('http://localhost:5240/StockInventory/ProductCreation', this.productObj, { headers }).subscribe(
      (res) => {
        if (res.result) {
          alert("Product Created Successfully");
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
