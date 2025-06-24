import { Component } from '@angular/core';
import { ContactForm } from '../../core/models/ContactForm.interface';
import { ContactService } from '../../core/services/contact.service';
import { ContactResponse } from '../../core/models/ContactResponse.model';

@Component({
  selector: 'app-contact-section',
  standalone: false,
  templateUrl: './contact-section.component.html',
  styleUrl: './contact-section.component.css'
})
export class ContactSectionComponent {
  form: ContactForm = {
    name: '',
    email: '',
    phone: '',
    category: '',
    message: ''
  };

  successMessage: string = '';
  errorMessage: string = '';

  constructor(private contactService: ContactService) {}

  saveForm() {
    this.contactService.sendContactForm(this.form).subscribe({
      next: (response: ContactResponse) => {
        this.successMessage = response.message;
        this.resetForm();
      },
      error: () => {
        this.successMessage = '';
        this.errorMessage = 'Hubo un error al enviar tu mensaje. Intenta nuevamente.';
      }
    });
  }

  resetForm() {
    this.errorMessage = '';
    this.form = {
      name: '',
      email: '',
      phone: '',
      category: '',
      message: ''
    };
  }
}
