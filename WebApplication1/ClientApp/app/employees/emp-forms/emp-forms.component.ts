import { EmployeeService } from './../../../services/employee.service';
import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms'
@Component({
  selector: 'app-emp-forms',
  templateUrl: './emp-forms.component.html',
  styleUrls: ['./emp-forms.component.css']
})
export class EmpFormsComponent implements OnInit {

  constructor(public service:EmployeeService) {

   }

  ngOnInit(): void {
    this.resetForm();
     

  }
   resetForm(data?:NgForm){
    if(data != null)
    {
      data.resetForm();
    }
  
    this.service.Employee= {
      departmentID:null,
      departmentName:'',
      id:null,
      name:'',
      salary:null

    }
  
   }
  
  SubmitForm(data:NgForm){
    if(data.valid){
    this.service.PostEmployees(data.value).subscribe(a=>{
      alert("The employee is added");
      this.resetForm(data);
      this.service.GetEmployees();
     

      
    });
    }

  }

}
