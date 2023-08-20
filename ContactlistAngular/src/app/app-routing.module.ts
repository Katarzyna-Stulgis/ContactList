import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { AuthComponent } from './components/auth/auth.component';
import { EditContactComponent } from './components/edit-contact/edit-contact.component';
import { AuthGuard } from './services/auth.guard';

const routes: Routes = [
  { path: '', component: ContactsComponent },
  { path: 'auth', component: AuthComponent },
  { path: 'contacts/:id', component: ContactDetailsComponent },
  { path: 'contacts/:id/edit-contact', component: EditContactComponent, canActivate: [AuthGuard]  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
