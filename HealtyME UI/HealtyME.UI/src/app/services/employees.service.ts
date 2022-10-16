import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.models';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseApiUrl: string = environment.baseUrl;
  constructor(private http:HttpClient) { }

  getAllEmployees():Observable<Employee[]>{

    return this.http.get<Employee[]>(this.baseApiUrl+"api/Employee");
  }

  addEmployee(addEmployeeReq:Employee):Observable<Employee>
  {
    addEmployeeReq.id ="00000000-0000-0000-0000-000000000000";
   return this.http.post<Employee>(this.baseApiUrl+"api/Employee",addEmployeeReq)
  }

  getEmployee(id:string): Observable<Employee>{
    return this.http.get<Employee>(this.baseApiUrl+"api/Employee/"+id)
  }

  updateEmployee(id:string,updateEmployeeReq:Employee): Observable<Employee>{
    return this.http.put<Employee>(this.baseApiUrl+"api/Employee/"+id,updateEmployeeReq)
  }
  deleteEmployee(id:string): Observable<Employee>{
    return this.http.delete<Employee>(this.baseApiUrl+"api/Employee/"+id)
  }
}