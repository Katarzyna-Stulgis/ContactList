import { Component, Input, OnInit } from '@angular/core';
import { IContact } from 'src/app/interfaces/IContact';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  @Input() contact: IContact = {} as IContact;

  constructor() { }

  ngOnInit(): void {
  }

}
