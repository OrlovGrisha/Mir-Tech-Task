export class Employee{
    id?: number;
    fullName?: string = "";
    department?: string = "";
    birthday?: Date = new Date();
    hireDate?: Date = new Date();
    salary?: number = 0;

    constructor(id?: number, fullName?: string, department?: string, birthday?: Date, hireDate?: Date, salary?: number){
        this.id = id;
        this.fullName = fullName;
        this.department = department;
        this.birthday = birthday;
        this.hireDate = hireDate;
        this.salary = salary;
    }
}