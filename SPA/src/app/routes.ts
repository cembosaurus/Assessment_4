import { FormComponent } from './form/form.component';
import { HomeComponent } from './home/home.component';
import { Routes } from '@angular/router';
import { CheckComponent } from './check/check.component';


export const AppRoutes: Routes = [
    {path: 'check/:payee/:amount/:amountInWords/:date', component: CheckComponent},
    {path: 'home', component: HomeComponent},
    {path: 'form', component: FormComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'}
];
