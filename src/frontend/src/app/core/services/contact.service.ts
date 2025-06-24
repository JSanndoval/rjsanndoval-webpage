import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ContactForm } from '../models/ContactForm.interface';
import { Observable } from 'rxjs';
import { ContactResponse } from '../models/ContactResponse.model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  // private apiUrl = 'https://localhost:44300/api/contact'; //DEV
  private apiUrl = 'https://backend-rjsanndoval-webpage.onrender.com/api/contact'; //PROD

  constructor(private http: HttpClient) { }

  sendContactForm(formData: ContactForm): Observable<ContactResponse> {
    return this.http.post<ContactResponse>(this.apiUrl, formData);
  }
}
