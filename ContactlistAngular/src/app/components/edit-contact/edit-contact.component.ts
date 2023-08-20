import { ContactService } from './../../services/contact.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IContact } from 'src/app/interfaces/IContact';
import { IContactCategory } from 'src/app/interfaces/IContactCategory';
import { IContactSubcategory } from 'src/app/interfaces/IContactSubcategory';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  phoneFormControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]{9}$')]);
  firstNameFormControl = new FormControl('', [Validators.required,Validators.pattern('^[a-zA-Z]*$')]);
  lastNameFormControl = new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z]*$')]);
  birthDateFormControl = new FormControl('', [Validators.required]);

  @Output() contactsUpdated = new EventEmitter<IContact>();
  private routeSub: Subscription = {} as Subscription;
  contact: IContact = {} as IContact;
  contactId: string = "";
  categories: IContactCategory[] = [];
  category: IContactCategory = {} as IContactCategory;
  isValidForm: boolean = false;
  contactCategoryName = "";

  businessSubcategories?: IContactSubcategory[] | null = [];

  constructor(
    private contactService: ContactService,
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.contactId = params['id'];
    });
    this.getContact();
    this.getContactCategory();
    this.getCategories();
  }

  getContact() {
    this.contactService
      .getContact(this.contactId)
      .subscribe((result: IContact) => {
        this.contact = result;
      })
  }

  onSelectedOptionChange() {
    this.contact.subcategory = "";
  }

  getContactCategory() {
    this.categoryService
      .getContactCategories()
      .subscribe((result: IContactCategory[]) => {
        this.categories = result;
        const foundCategory = this.categories.find(category => category.id == this.contact.contactCategoryId);
        if (foundCategory) {
          this.contact.category = foundCategory;
          this.contactCategoryName = foundCategory.name;
        }
      })
  }

  getCategories() {
    this.categoryService
      .getContactCategories()
      .subscribe((result: IContactCategory[]) => {
        this.categories = result;
        this.businessSubcategories = (this.categories.find(category => category.name == "służbowy"))?.contactSubcategories;
      });
  }

  Save() {
    this.isValidForm = this.emailFormControl.valid
      && this.phoneFormControl.valid
      && this.firstNameFormControl.valid
      && this.lastNameFormControl.valid
      && this.birthDateFormControl.valid

    if (this.contactCategoryName == "prywatny") {
      this.contact.subcategory = null;
    }
    if (this.isValidForm) {
      let contactCategory = this.categories.find(category => category.name == this.contactCategoryName) as IContactCategory

      this.contact.category = contactCategory;
      this.contact.contactCategoryId = contactCategory.id

      this.contactService
        .editContact(this.contact)
        .subscribe((contacts: IContact) => {
          this.contactsUpdated.emit(contacts);

          this.router.navigate(['/']);
        })
    }
  }
}
