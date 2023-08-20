import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ILoginUser } from 'src/app/interfaces/ILoginUser';
import { IRegisterUser } from 'src/app/interfaces/IRegisterUser';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required, Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}')]);
  confirmPasswordControl = new FormControl('', Validators.required);

  loginUser: ILoginUser = {} as ILoginUser;
  registerUser: IRegisterUser = {} as IRegisterUser;

  selectedIndex: number = 0;

  constructor(
    private authService: AuthService,
    public router: Router,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
  }


  register(user: IRegisterUser) {
    this.authService.register(user).subscribe(
      (data) => {
        this._snackBar.open("Pomyślnie zarejestrowano", "",
          {
            duration: 1500,
          });
        this.selectedIndex = 0;
      },
      (error: HttpErrorResponse) => {
        this._snackBar.open("Coś poszło nie tak, spróbuj ponownie", "",
          {
            duration: 1500,
          });
        this.selectedIndex = 1;
      });
  }

  login(user: ILoginUser) {
    this.authService.login(user).subscribe(
      (token: string) => {
        localStorage.setItem('authToken', token);
        this.router.navigate(['/'])
          .then(() => {
            window.location.reload();
          });
      },
      (error) => {
        this._snackBar.open("Nieprawidłowy e-mail lub hasło", "",
          {
            duration: 1500,
          });
      }
    )
  }
}
