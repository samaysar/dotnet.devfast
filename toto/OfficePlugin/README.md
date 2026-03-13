## Angular 21 Office Add-in scaffold

This project is a minimal **Microsoft Office task pane add-in** built with **Angular 21 + TypeScript** and the standard modern JS tooling stack (Angular CLI style layout, ESLint, Prettier).

### Prerequisites

- Node.js 20.19+ (LTS) and npm
- Microsoft 365 desktop (e.g. Word or Excel)
- The Office Add-in development tools (for sideloading the manifest), for example:
  - Office on the web: upload `manifest.xml` via the admin center
  - Office on desktop: sideload using the **Shared folder catalog** or **Network share** method

### Install dependencies

```bash
cd d:/EverythingElse/toto/OfficePlugin
npm install
```

### Run the Angular dev server

```bash
npm start
```

By default this uses HTTP on port 4200. Office add-ins require **HTTPS**, so for real sideloading you should:

- Configure Angular dev server with `--ssl true --ssl-cert` and `--ssl-key`, or
- Proxy through a local HTTPS dev server that terminates TLS and forwards to `http://localhost:4200`.

Once you have HTTPS serving on `https://localhost:4200`, update `manifest.xml` if you change host/port.

### Use the add-in in Office

1. Ensure the app is running and accessible at `https://localhost:4200`.
2. Sideload `manifest.xml` into Word or Excel (follow the official Office Add-in sideloading guide).
3. Open a document, then:
   - Go to the **Home** tab.
   - Click **Show Angular Pane** in the custom group.
4. In Word, use **Insert sample text** in the task pane to insert text at the current selection.

