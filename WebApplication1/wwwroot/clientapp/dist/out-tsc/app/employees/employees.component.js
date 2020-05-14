import { __decorate } from "tslib";
import { Component } from '@angular/core';
let EmployeesComponent = class EmployeesComponent {
    constructor(EmployeeService) {
        this.EmployeeService = EmployeeService;
    }
    ngOnInit() {
    }
    EditEmployee(id) {
        console.log(id);
    }
    DeleteEmployee(id) {
        console.log(id);
    }
};
EmployeesComponent = __decorate([
    Component({
        selector: 'app-employees',
        templateUrl: './employees.component.html',
        styleUrls: ['./employees.component.css']
    })
], EmployeesComponent);
export { EmployeesComponent };
//# sourceMappingURL=employees.component.js.map