import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../company.service';

@Component({
  selector: 'app-view-company',
  templateUrl: './view-company.component.html',
  styleUrls: ['./view-company.component.css']
})
export class ViewCompanyComponent implements OnInit {

  constructor(public service:CompanyService) { }

  ngOnInit(): void {
  }

}
