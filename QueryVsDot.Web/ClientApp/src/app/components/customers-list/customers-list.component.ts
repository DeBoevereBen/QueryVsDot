import { AppServiceService } from './../../services/app-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.css']
})
export class CustomersListComponent implements OnInit {
  public name: string;
  public customers: any;
  constructor(private service: AppServiceService) {}

  ngOnInit() {
    this.name = '';
  }
  getCustomers() {
    this.service.getCustomers(this.name).subscribe(customer => {
      this.customers = customer;
      console.log(this.customers);
    });
  }
}
