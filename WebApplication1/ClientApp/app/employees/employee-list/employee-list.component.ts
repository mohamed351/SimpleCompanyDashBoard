import { EmployeeService } from './../../../services/employee.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(public emp:EmployeeService) { }

  ngOnInit(): void {
    this.emp.GetEmployees();
  }
  DeleteEmployees(id:number){
  
  }

}
