import { ContactService } from './../../services/contact.service';
import { Component, OnInit } from '@angular/core';
import { IContact } from 'src/app/interfaces/IContact';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  contacts: IContact[] = [];

  constructor(
    private contactService: ContactService
  ) { }

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts() {
    this.contactService
      .getContacts()
      .subscribe((result: IContact[]) => { this.contacts = result });
  }
}
