import { Employee } from './../models/Employee';
import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  Employee:Employee;
  EmployeesList:Employee[];
    constructor(private httpClient:HttpClient) { }

    GetEmployees() {

        return this.httpClient.get<Employee[]>("/api/Employees")
        .toPromise()
        .then(a=> this.EmployeesList = a as Employee[]);
    }

    PostEmployees(emp:Employee){
      return this.httpClient.post("/api/Employees",emp);
    }
    DeleteEmployees(id:number){
      return this.httpClient.delete("/api/Employees/"+id);
    }
}
