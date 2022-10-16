import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.models';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  constructor(private employeeService:EmployeesService, private router:Router) { }
  addEmployeeReq: Employee ={
    id:'',
    department:'',
    email:'',
    name:'',
    phone:0,
    salary:0
  }

  ngOnInit(): void {
  }

  addEmployee(){
    this.employeeService.addEmployee(this.addEmployeeReq).subscribe(
      {
        next:(employee) =>{
          this.router.navigate(["employees"]);
        }

      }
    );
    console.log(this.addEmployeeReq)
  }

}
