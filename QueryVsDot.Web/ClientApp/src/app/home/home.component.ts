import { AppServiceService } from './../services/app-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  public categories: any;
  public loaded: boolean;
  constructor(private service: AppServiceService) {}
  ngOnInit() {
    this.loaded = false;
    this.service.getCategories().subscribe(categorie => {
      this.categories = categorie;
      this.loaded = true;
    });
  }
}
