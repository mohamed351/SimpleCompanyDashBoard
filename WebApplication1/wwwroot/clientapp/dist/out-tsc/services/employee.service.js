import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let EmployeeService = class EmployeeService {
    constructor(httpClient) {
        this.httpClient = httpClient;
    }
    GetEmployees() {
        return this.httpClient.get("/api/Employees")
            .toPromise()
            .then(a => this.EmployeesList = a);
    }
    PostEmployees(emp) {
        return this.httpClient.post("/api/Employees", emp);
    }
    DeleteEmployees(id) {
        return this.httpClient.delete("/api/Employees/" + id);
    }
};
EmployeeService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], EmployeeService);
export { EmployeeService };
//# sourceMappingURL=employee.service.js.map