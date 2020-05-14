import { __decorate } from "tslib";
import { Component } from '@angular/core';
let EmployeeListComponent = class EmployeeListComponent {
    constructor(emp) {
        this.emp = emp;
    }
    ngOnInit() {
        this.emp.GetEmployees();
    }
    DeleteEmployees(id) {
    }
};
EmployeeListComponent = __decorate([
    Component({
        selector: 'app-employee-list',
        templateUrl: './employee-list.component.html',
        styleUrls: ['./employee-list.component.css']
    })
], EmployeeListComponent);
export { EmployeeListComponent };
//# sourceMappingURL=employee-list.component.js.map