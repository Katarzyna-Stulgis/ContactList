import { AuthService } from 'src/app/services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IContact } from '../interfaces/IContact';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private url = "contacts"

  constructor(private authService: AuthService, private httpClient: HttpClient) { }

  public getContacts(): Observable<IContact[]> {
    return this.httpClient.get<IContact[]>(`${environment.apiUrl}/${this.url}`);
  }

  public getContact(contactId: string): Observable<IContact> {
    return this.httpClient.get<IContact>(`${environment.apiUrl}/${this.url}/${contactId}`);
  }

  public addContact(contact: IContact): Observable<IContact> {
    return this.httpClient.post<IContact>(`${environment.apiUrl}/${this.url}`, contact);
  }

  public editContact(contact: IContact): Observable<IContact> {
    return this.httpClient.put<IContact>(`${environment.apiUrl}/${this.url}/${contact.id}`, contact);
  }

  public deleteContact(contactId: string): Observable<IContact> {
    return this.httpClient.delete<IContact>(`${environment.apiUrl}/${this.url}/${contactId}`);
  }
}
