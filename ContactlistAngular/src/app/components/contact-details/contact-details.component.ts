import { CategoryService } from './../../services/category.service';
import { ContactService } from './../../services/contact.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription, take } from 'rxjs';
import { IContact } from 'src/app/interfaces/IContact';
import { IContactCategory } from 'src/app/interfaces/IContactCategory';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {

  contact: IContact = {} as IContact;
  contactId: string = "";
  private routeSub: Subscription = {} as Subscription;
  userIsLoggedIn: boolean = false;
  categories: IContactCategory[] = [];
  category: IContactCategory = {} as IContactCategory;
  contactCategory = "";

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService,
    private authService: AuthService,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.authService.isLoggedIn.subscribe(
      logged => this.userIsLoggedIn = logged);

    this.routeSub = this.route.params.subscribe(params => {
      this.contactId = params['id'];
    });
    this.getContact();
    this.getContactCategory();
  }

  getContact() {
    this.contactService
      .getContact(this.contactId)
      .subscribe((result: IContact) => {
        this.contact = result;
      })
  }

  getContactCategory() {
    this.categoryService
      .getContactCategories()
      .subscribe((result: IContactCategory[]) => {
        this.categories = result;
        const foundCategory = this.categories.find(category => category.id == this.contact.contactCategoryId);
        if (foundCategory) {
          this.contact.category = foundCategory;
          this.contactCategory = foundCategory.name;
        }
      })
  }

  Delete() {
    this.contactService
      .deleteContact(this.contact.id)
      .subscribe(data => window.location.reload())
  }
}
