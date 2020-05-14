import { __decorate } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeesComponent } from './employees/employees.component';
import { DepartmentComponent } from './department/department.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { AuthicationComponent } from './nav/authication/authication.component';
import { EmpFormsComponent } from './employees/emp-forms/emp-forms.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeService } from '../services/employee.service';
let router = [{ path: "", component: EmployeesComponent },
    { path: "Department", component: DepartmentComponent }];
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            EmployeesComponent,
            DepartmentComponent,
            NavComponent,
            LoginComponent,
            RegistrationComponent,
            AuthicationComponent,
            EmpFormsComponent,
            EmployeeListComponent,
        ],
        imports: [
            BrowserModule,
            AppRoutingModule,
            HttpClientModule,
            FormsModule,
            RouterModule.forRoot(router)
        ],
        providers: [EmployeeService],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map