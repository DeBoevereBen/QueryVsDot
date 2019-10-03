import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {
  private url: string;
  constructor(private http: HttpClient) {
      this.url = 'https://localhost:44358/api/product/categories';
  }
  getProductsInCategory(id: number) {
    return this.http.get(this.url + '/' + id);
  }
  getCategories() {
    return this.http.get(this.url);
  }
  getCustomers(name: string) {
      return this.http.get('https://localhost:44358/api/customer/search/' + name);
  }
}
