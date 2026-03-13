import { Component, signal } from '@angular/core';

/* global Office */

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  readonly title = 'Office Angular Add-in';
  readonly isOfficeReady = signal<boolean>(false);
  readonly host = signal<string>('Unknown');

  constructor() {
    if (typeof Office !== 'undefined') {
      Office.onReady().then((info) => {
        this.isOfficeReady.set(true);
        this.host.set(info.host.toString());
      });
    }
  }

  async insertText(): Promise<void> {
    if (typeof Office === 'undefined') {
      // eslint-disable-next-line no-alert
      alert('Office.js is not available. Open this add-in inside an Office host like Excel or Word.');
      return;
    }

    try {
      await Word.run(async (context) => {
        const selection = context.document.getSelection();
        selection.insertText('Hello from Angular Office Add-in!', Word.InsertLocation.replace);
        await context.sync();
      });
    } catch (error) {
      // eslint-disable-next-line no-console
      console.error(error);
    }
  }
}

