import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Employee } from "../classes/Employee";
import { Observable, map } from "rxjs";
import { EmployeeFilter } from "../classes/EmployeeFilter";

@Injectable()
export class HttpToEmployees {


  constructor(private http: HttpClient) {}

  getEmployees(filters: EmployeeFilter, descOrder: boolean, sortedBy: string): Observable<Employee[]> {

    let params = new HttpParams();

    if (filters.fullName) {
      params = params.set('FullName', filters.fullName);
    }
    if (filters.department) {
      params = params.set('Department', filters.department);
    }
    if (filters.leftBirthday) {
      params = params.set('LeftBirthday', filters.leftBirthday.toString());
    }
    if (filters.rightBirthday) {
      params = params.set('RightBirthday', filters.rightBirthday.toString());
    }
    if (filters.leftHireDate) {
      params = params.set('LeftHireDate', filters.leftHireDate.toString());
    }
    if (filters.rightHireDate) {
      params = params.set('RightHireDate', filters.rightHireDate.toString());
    }
    if (filters.leftSalary != null) {
      params = params.set('LeftSalary', filters.leftSalary.toString());
    }
    if (filters.rightSalary != null) {
      params = params.set('RightSalary', filters.rightSalary.toString());
    }
    if (!descOrder){
        params = params.set("descOrder", descOrder);
    }
    if (sortedBy){
        params = params.set("sortedBy", sortedBy)
    }

    return this.http.get<any[]>("https://localhost:44322/Employees/get", {params})
      .pipe(
        map(responseArray =>
          responseArray.map(item => new Employee(
            item.id,
            item.fullName,
            item.department,
            item.birthday,
            item.hireDate,
            item.salary
          ))
        )
      );
  }

  editEmployee(employee: Employee): Observable<any> {

  let data = {
    "fullName": employee.fullName,
    "department": employee.department,
    "hireDate": employee.hireDate,
    "birthday": employee.birthday,
    "salary": employee.salary
  };

  const url = `https://localhost:44322/Employees/update/${employee.id}`;

  return this.http.patch(url, data, {
    headers: { 'Content-Type': 'application/json' }
  });
  }

  addEmployee(employee: Employee): Observable<any>{
    let data = {
    "fullName": employee.fullName,
    "department": employee.department,
    "hireDate": employee.hireDate,
    "birthday": employee.birthday,
    "salary": employee.salary
  };

  const url = `https://localhost:44322/Employees/add`;

  return this.http.post(url, data, {
    headers: { 'Content-Type': 'application/json' }
  });
  }

  deleteEmployee(employee: Employee){
    return this.http.delete(`https://localhost:44322/Employees/delete/${employee.id}`)
  }
}
