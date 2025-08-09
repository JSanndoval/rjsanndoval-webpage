// app.component.ts
import { Component, OnInit, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser, CommonModule } from '@angular/common';
import { Router, NavigationEnd } from '@angular/router';
import { environment } from './environments/environment';

declare global {
  interface Window {
    dataLayer: any[];
    gtag: (...args: any[]) => void;
  }
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private gaId = environment.gaMeasurementId ?? 'G-HC0SGWS4K3';

  constructor(
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  ngOnInit() {
    if (!environment.production) return;                 // solo en prod
    if (!isPlatformBrowser(this.platformId)) return;     // solo en navegador

    // Evitar doble inyección
    if (!document.getElementById('ga4-script')) {
      const s1 = document.createElement('script');
      s1.async = true;
      s1.src = `https://www.googletagmanager.com/gtag/js?id=${this.gaId}`;
      s1.id = 'ga4-script';
      document.head.appendChild(s1);

      const s2 = document.createElement('script');
      s2.id = 'ga4-inline';
      s2.innerHTML = `
        window.dataLayer = window.dataLayer || [];
        function gtag(){window.dataLayer.push(arguments);}
        gtag('js', new Date());
        gtag('config', '${this.gaId}');
      `;
      document.head.appendChild(s2);
    }

    // Page views en cada cambio de ruta
    this.router.events.subscribe(ev => {
      if (ev instanceof NavigationEnd && window.gtag) {
        window.gtag('config', this.gaId, {
          page_path: ev.urlAfterRedirects
        });
      }
    });
  }
}
