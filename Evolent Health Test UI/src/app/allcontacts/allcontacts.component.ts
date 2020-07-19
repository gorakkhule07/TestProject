import { Component, OnInit } from '@angular/core';
import { ContactService } from '../Services/contact.service';


@Component({
  selector: 'app-allcontacts',
  templateUrl: './allcontacts.component.html',
  styleUrls: ['./allcontacts.component.css']
})
export class AllContactsComponent implements OnInit {

  public data: any;
  public tempdata: any;
  public UserMessage: any;
  constructor(private contactService: ContactService) { }

  ngOnInit() {
    this.getAllContacts();
  }
  getAllContacts()
  {
    this.contactService.getAllContacts().subscribe(
      (res: any) => {
        console.log(res);
        this.data = res;
        this.tempdata = res;
      });
  }
  onSearchChange(input: any) {
    console.log(input);
    this.data = this.tempdata;
    this.data = this.data.filter(item => {
      return item.email.toLowerCase().includes(input.toLowerCase());
    });
  }
  DeleteContact(id: number) {
    this.contactService.DeleteContact(id).subscribe((response: any) => {
      console.log(response);
      if (response == 'Success') {
        this.UserMessage = 'Contact deleted successfully.';
        this.getAllContacts();
      }
      else{
        this.UserMessage = 'Unable to delete record.';
      }
    })
  }

}
