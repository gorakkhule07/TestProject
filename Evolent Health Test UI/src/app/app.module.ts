import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NewContactComponent } from './newcontact/newcontact.component';
import { AppRoutingModule } from './app-routing.module';
import { FormBuilder, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AllContactsComponent } from './allcontacts/allcontacts.component';
import { DataTableModule } from "angular-6-datatable";

@NgModule({
  declarations: [
    AppComponent,
    NewContactComponent,
    AllContactsComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    DataTableModule,
  ],
  
  providers: [FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
