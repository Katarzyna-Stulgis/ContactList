import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from './shared/material.module';
import { ContactsComponent } from './components/contacts/contacts.component';
import { ContactComponent } from './components/contacts/contact/contact.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';
import { AuthComponent } from './components/auth/auth.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth.guard';
import { EditContactComponent } from './components/edit-contact/edit-contact.component';
import { AddContactComponent } from './components/add-contact/add-contact.component';
import { JWT_OPTIONS, JwtModule } from '@auth0/angular-jwt';
import { JwtInterceptor } from './classes/JwtInterceptor';

export function jwtOptionsFactory() {
    return {
        allowedDomains: ['https://localhost:7055']
    };
}

@NgModule({
    declarations: [
        AppComponent,
        ContactsComponent,
        ContactComponent,
        ContactDetailsComponent,
        AuthComponent,
        EditContactComponent,
        AddContactComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,

        MaterialModule,

        JwtModule.forRoot({
            jwtOptionsProvider: {
                provide: JWT_OPTIONS,
                useFactory: jwtOptionsFactory
            }
        })
    ],
    providers: [AuthService,
        {
            provide: APP_INITIALIZER,
            useFactory: (service: AuthService) => function () { return service.UserIsLoggedIn(); },
            deps: [AuthService],
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true
        },
        AuthGuard],
    bootstrap: [AppComponent]
})
export class AppModule { }
