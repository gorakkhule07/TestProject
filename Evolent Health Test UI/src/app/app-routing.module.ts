import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewContactComponent } from './newcontact/newcontact.component';
import { AllContactsComponent } from './allcontacts/allcontacts.component';


const routes: Routes = [
    { path: '', component: NewContactComponent },
    { path: 'newcontact', component: NewContactComponent },
    { path: 'allcontacts', component: AllContactsComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }