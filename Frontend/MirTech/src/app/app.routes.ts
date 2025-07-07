import { Routes } from '@angular/router';
import { About } from '../pages/about/about';
import { Employees } from '../pages/employees/employees';

export const routes: Routes = [
    {path: 'about', component: About},
    {path: 'employees', component: Employees}
];
