import { Component, ElementRef, AfterViewInit } from '@angular/core';

declare var bootstrap: any;

@Component({
  selector: 'app-navbar',
  standalone: false,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  constructor(private el: ElementRef) {}

  ngAfterViewInit(): void {
    const nativeElement = this.el.nativeElement as HTMLElement;
    const navLinks = nativeElement.querySelectorAll('.nav-link');
    const navbarCollapse = document.getElementById('navbarSupportedContent');

    navLinks.forEach((link) => {
      link.addEventListener('click', (event) => {
        const href = (link as HTMLAnchorElement).getAttribute('href');

        if (href && href.startsWith('#')) {
          event.preventDefault();

          const target = document.querySelector(href);
          if (target) {
            target.scrollIntoView({ behavior: 'smooth' });
          }
        }

        // Cerrar el menú si está expandido (en vista móvil)
        if (navbarCollapse && navbarCollapse.classList.contains('show')) {
          const bsCollapse =
            bootstrap.Collapse.getInstance(navbarCollapse) ||
            new bootstrap.Collapse(navbarCollapse, { toggle: false });
          bsCollapse.hide();
        }
      });
    });
  }
}
