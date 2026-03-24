## React Office SSO Add-in scaffold

This project is a minimal **Microsoft Office task pane add-in** built with **React + TypeScript + Vite** and configured with **ESLint, Prettier, Husky, and lint-staged**.

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

### Run the React dev server

```bash
npm start
```

By default this uses HTTP on port 4200. Office add-ins require **HTTPS**, so for sideloading you should:

- Configure Vite with HTTPS cert/key, or
- Proxy through a local HTTPS dev server that terminates TLS and forwards to `http://localhost:4200`.

Once you have HTTPS serving on `https://localhost:4200`, update `manifest.xml` if you change host/port.

### Office SSO setup (required)

1. Register an Azure app for your add-in.
2. Replace placeholders in `manifest.xml`:
   - `ov:WebApplicationInfo/ov:Id`
   - `ov:WebApplicationInfo/ov:Resource`
3. Add redirect URI(s) for your local/dev host.
4. Grant delegated permissions your add-in needs and grant admin consent if required.

### Use the add-in in Office

1. Ensure the app is running and accessible at `https://localhost:4200`.
2. Sideload `manifest.xml` into Word or Excel (follow the official Office Add-in sideloading guide).
3. Open a document, then:
   - Go to the **Home** tab.
   - Click **Show React Pane** in the custom group.
4. In the task pane, click **Get SSO token** to trigger `OfficeRuntime.auth.getAccessToken`.
