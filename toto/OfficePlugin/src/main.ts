import { bootstrapApplication } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { AppComponent } from './app/app.component';

/* global Office */

function bootstrapAngular() {
  bootstrapApplication(AppComponent, {
    providers: [provideAnimations()]
  }).catch((err) => console.error(err));
}

if (typeof Office !== 'undefined') {
  Office.onReady(() => {
    bootstrapAngular();
  });
} else {
  // Fallback so the app can run outside of Office (for local dev in a browser)
  bootstrapAngular();
}

