import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  public e
  constructor(private httpclient: HttpClient) {
  }
  
  saveContact(ContactEntity: any) {
    return this.httpclient.post(environment.apiURL + 'Contact/SaveContact',ContactEntity);
  }
  GetContactById(Id: Number) {
    return this.httpclient.get(environment.apiURL + 'Contact/GetContactById?Id=' + Id);
  }
  getAllContacts() {
    return this.httpclient.get(environment.apiURL + 'Contact/GetAllContact');
  }
  
  updateContact(ContactEntity: any) {
    return this.httpclient.put(environment.apiURL + 'Contact/UpdateContact',ContactEntity);
  }
  DeleteContact(Id: Number) {
    return this.httpclient.delete(environment.apiURL + 'Contact/DeleteContact?Id=' + Id);
  }
 

  
}
