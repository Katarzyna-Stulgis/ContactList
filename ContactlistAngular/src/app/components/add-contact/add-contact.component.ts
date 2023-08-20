import { ContactService } from './../../services/contact.service';
import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IContact } from 'src/app/interfaces/IContact';
import { IContactCategory } from 'src/app/interfaces/IContactCategory';
import { IContactSubcategory } from 'src/app/interfaces/IContactSubcategory';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {
  @Output() contactsUpdated = new EventEmitter<IContact>();
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  phoneFormControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]{9}$')]);
  firstNameFormControl = new FormControl('', [Validators.required,Validators.pattern('^[a-zA-Z]*$')]);
  lastNameFormControl = new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z]*$')]);
  birthDateFormControl = new FormControl('', [Validators.required]);
  categoryFormControl = new FormControl('', [Validators.required]);

  isValidForm: boolean = false;

  categories: IContactCategory[] = [];
  businessSubcategories?: IContactSubcategory[] | null = [];
  pickedCategory: IContactCategory = {} as IContactCategory;
  pickedSubcategory?: IContactSubcategory | null = {} as IContactSubcategory;

  contact: IContact = {} as IContact;

  constructor(
    public dialogRef: MatDialogRef<AddContactComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IContact,
    private contactService: ContactService,
    private categoryService: CategoryService,
  ) { }

   ngOnInit(): void {
    this.getCategories();
  }

  AddContact() {

    this.isValidForm = this.emailFormControl.valid
      && this.phoneFormControl.valid
      && this.firstNameFormControl.valid
      && this.lastNameFormControl.valid
      && this.birthDateFormControl.valid
      && this.categoryFormControl.valid

    if (this.pickedCategory.name == "prywatny") {
      this.pickedSubcategory = null;
      this.data.subcategory = null;
    }
    if (this.isValidForm) {
      this.data.contactCategoryId = this.pickedCategory.id;

      this.contactService
        .addContact(this.data)
        .subscribe((contacts: IContact) => {
          this.contactsUpdated.emit(contacts);
          window.location.reload();
        })

      this.dialogRef.close();
    }
  }

  getCategories() {
    this.categoryService
      .getContactCategories()
      .subscribe((result: IContactCategory[]) => {
        this.categories = result;
        this.businessSubcategories = (this.categories.find(category => category.name == "służbowy"))?.contactSubcategories;
        this.pickedCategory = this.categories[0];
      });
  }

  CloseDialog(): void {
    this.dialogRef.close();
  }
}
