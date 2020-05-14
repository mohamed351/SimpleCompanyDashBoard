import { Employee } from './../../models/Employee';
import { EmployeeService } from '../../services/employee.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {


  constructor(private EmployeeService:EmployeeService){

  }   

  ngOnInit(): void {
    
  }
  EditEmployee(id:number){
    console.log(id);
  }
  DeleteEmployee(id:number){
    console.log(id);
  }

}
