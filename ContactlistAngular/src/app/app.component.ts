import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';
import { AddContactComponent } from './components/add-contact/add-contact.component';
import { IContact } from './interfaces/IContact';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ContactlistAngular';
  userIsLoggedIn: boolean = false;
  useremail: string = "";
  contact: IContact= {} as IContact;

  constructor(public dialog: MatDialog,
    private authService: AuthService,
    public router: Router) { }

  ngOnInit(): void {
    this.authService.isLoggedIn.subscribe(
      logged => this.userIsLoggedIn = logged);

    if (this.userIsLoggedIn) {
      this.useremail = this.authService.getToken().email;
    }
  }

  openDialog(): void {
      this.dialog.open(AddContactComponent, {
        width: 'auto',
        data: { contact: this.contact},
      });
  }

  LogOut() {
    this.authService.logoutUser();
    this.router.navigate(['/'])
  }
}
