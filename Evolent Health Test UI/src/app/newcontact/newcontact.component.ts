
import { Component, OnInit, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ContactService } from '../Services/contact.service';
@Component({
  selector: 'app-newcontact',
  templateUrl: './newcontact.component.html',
  styleUrls: ['./newcontact.component.css']
})

export class NewContactComponent implements OnInit {

 
  isSubmitted = false;
  IsShowUsermessageError = false;
  IsShowUsermessageSuccess = false;
  UserMessage: string = '';
  model: any = { status: '-- Select Status --' };
  Operation = 'New';
  constructor(private router: ActivatedRoute,
    private route: Router,
    private contactService: ContactService
  ) { }

  ngOnInit() {

    this.model.id = this.router.snapshot.queryParamMap.get('id');
    if (Number(this.model.id) > 0) {
      this.contactService.GetContactById(this.model.id).subscribe((response: any) => {
        this.model = response;
        this.Operation = 'Update';
      });
    }
    else {
      this.model.id = 0;
      this.Operation = 'New';
    }

  }


  SaveContact() {
    this.isSubmitted = true;
    this.IsShowUsermessageSuccess = false;
    this.IsShowUsermessageError = false;
    this.UserMessage = '';
    if (
      this.model.firstName == '' || this.model.firstName == undefined ||
      this.model.lastName == '' || this.model.lastName == undefined ||
      this.model.status == '-- Select Status --' || this.model.status == undefined ||
      this.model.phoneNumber == '' || this.model.phoneNumber == undefined ||
      this.model.email == '' || this.model.email == undefined
    ) {
      return;
    }
    if (this.model.id > 0) {
      this.contactService.updateContact(this.model).subscribe((response: any) => {
        console.log(response);
        if (response == 'Success') {
          this.IsShowUsermessageSuccess = true;
          this.UserMessage = 'Contact updated successfully.';
          localStorage.setItem('userMessage', this.UserMessage);
          this.model = { status: '-- Select Status --' };
          this.isSubmitted = false;
          this.route.navigate(['/allcontacts']);

        }
        else if (response == 'DuplicateEmail') {
          this.IsShowUsermessageError = true;
          this.UserMessage = 'Email already present.';
          return;
        }
        else {
          this.IsShowUsermessageError = true;
          this.UserMessage = 'Unable to save contact.';
          return;
        }
      })
    }
    else {
      this.contactService.saveContact(this.model).subscribe((response: any) => {
        console.log(response);
        if (response == 'Success') {
          this.IsShowUsermessageSuccess = true;
          this.UserMessage = 'Contact saved successfully.';
          this.model = { status: '-- Select Status --' };
          this.isSubmitted = false;
          this.Operation = 'New';
          return;
        }
        else if (response == 'DuplicateEmail') {
          this.IsShowUsermessageError = true;
          this.UserMessage = 'Email already present.';
          return;
        }
        else {
          this.IsShowUsermessageError = true;
          this.UserMessage = 'Unable to save contact.';
          return;
        }
      })
    }
  }
}
