import { Component, OnInit } from '@angular/core';
import { HttpToEmployees } from '../../httpServices/httpToEmployees';
import { Employee } from '../../classes/Employee';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeFilter } from '../../classes/EmployeeFilter';

@Component({
  selector: 'app-employees',
  imports: [CommonModule, FormsModule],
  templateUrl: './employees.html',
  styleUrl: './employees.css',
  providers: [HttpToEmployees]
})

export class Employees implements OnInit{
  
  employees: Employee[] = [];

  constructor(private httpToEmployees: HttpToEmployees){ }

  ngOnInit(): void {
    this.httpToEmployees.getEmployees(this.filters, this.descOrder, this.sortedBy).subscribe(data => this.employees = data);
  }

  // Фильтры и сортировка
  filters: EmployeeFilter = {
  fullName: '',
  department: '',
  leftBirthday: undefined,
  rightBirthday: undefined,
  leftHireDate: undefined,
  rightHireDate: undefined,
  leftSalary: undefined,
  rightSalary: undefined
  };

  sortedBy: string = "fullName";
  descOrder: boolean = true;

  // Переменные модального окна добавления/редактирования
  modal: any;
  modalTitle: string = "";
  currentEmployee: Employee = new Employee();
  showModal: boolean = false;

  onSort(column: string, direction: boolean) {
  this.sortedBy = column;
  this.descOrder = direction;
  }

  onFiltersChanged(){
    this.httpToEmployees.getEmployees(this.filters, this.descOrder, this.sortedBy).subscribe(data => {this.employees = data; console.log(data);});
  }

  // Создание модальных окон
  openCreateModal(){
    this.modalTitle = "Создание сотрудника";
    this.currentEmployee = new Employee();
    this.showModal = true;
  }

  openEditModal(emp: Employee){
    this.modalTitle = "Редактирование сотрудника";
    this.currentEmployee = { ...emp }; // создаём копию, чтобы не менять данные сразу
    this.showModal = true;
  }

  saveEmployee(currentEmployee: Employee){
    console.log(currentEmployee);
    this.showModal = false;

    if (this.modalTitle == "Редактирование сотрудника"){
      this.httpToEmployees.editEmployee(currentEmployee).subscribe(() => this.onFiltersChanged());
    }

    if (this.modalTitle == "Создание сотрудника"){
      this.httpToEmployees.addEmployee(currentEmployee).subscribe(() => this.onFiltersChanged());
    }
  }

  openDeleteModal(employee: Employee) {
  this.currentEmployee = employee;
  }

  confirmDelete(){
    this.httpToEmployees.deleteEmployee(this.currentEmployee).subscribe(() => this.onFiltersChanged());
  }
}
