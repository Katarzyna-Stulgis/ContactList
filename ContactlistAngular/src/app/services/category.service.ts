import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IContactCategory } from '../interfaces/IContactCategory';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private url = "ContactCategories"

  constructor(private httpClient: HttpClient) { }

  public getContactCategories(): Observable<IContactCategory[]> {
    return this.httpClient.get<IContactCategory[]>(`${environment.apiUrl}/${this.url}`);
  }
}
