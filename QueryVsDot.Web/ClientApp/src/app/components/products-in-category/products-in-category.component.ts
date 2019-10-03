import { AppServiceService } from './../../services/app-service.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-products-in-category',
  templateUrl: './products-in-category.component.html',
  styleUrls: ['./products-in-category.component.css']
})
export class ProductsInCategoryComponent implements OnInit {
  public products: any;
  public id: number;
  public loaded: boolean;

  constructor(
    private route: ActivatedRoute,
    private service: AppServiceService
  ) {}

  ngOnInit() {
    this.loaded = false;
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.service.getProductsInCategory(this.id).subscribe(product => {
      this.products = product;
      this.loaded = true;
    });
  }
}
