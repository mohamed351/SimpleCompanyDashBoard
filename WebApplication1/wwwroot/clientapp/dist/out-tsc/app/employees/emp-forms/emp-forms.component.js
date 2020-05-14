import { __decorate } from "tslib";
import { Component } from '@angular/core';
let EmpFormsComponent = class EmpFormsComponent {
    constructor(service) {
        this.service = service;
    }
    ngOnInit() {
        this.resetForm();
    }
    resetForm(data) {
        if (data != null) {
            data.resetForm();
        }
        this.service.Employee = {
            departmentID: null,
            departmentName: '',
            id: null,
            name: '',
            salary: null
        };
    }
    SubmitForm(data) {
        if (data.valid) {
            this.service.PostEmployees(data.value).subscribe(a => {
                alert("The employee is added");
                this.resetForm(data);
                this.service.GetEmployees();
            });
        }
    }
};
EmpFormsComponent = __decorate([
    Component({
        selector: 'app-emp-forms',
        templateUrl: './emp-forms.component.html',
        styleUrls: ['./emp-forms.component.css']
    })
], EmpFormsComponent);
export { EmpFormsComponent };
//# sourceMappingURL=emp-forms.component.js.map