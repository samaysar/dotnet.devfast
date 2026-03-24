## React Excel SSO Add-in scaffold

This project is a minimal **Microsoft Excel task pane add-in** built with **React + TypeScript + Vite** and configured with **ESLint, Prettier, Husky, and lint-staged**.

### Prerequisites

- Node.js 20.19+ (LTS) and npm
- Microsoft 365 desktop Excel
- The Office Add-in development tools (for sideloading the manifest), for example:
  - Office on the web: upload `manifest.xml` via the admin center
  - Office on desktop: sideload using the **Shared folder catalog** or **Network share** method

### Install dependencies

```bash
cd d:/EverythingElse/toto/OfficePlugin
npm install
```

### Local dev (auto-open Excel like Yo Office)

```bash
npm start
```

This now uses Office add-in debugging tooling to:

- start the local dev server over HTTPS,
- sideload `manifest.xml`,
- launch Excel desktop and load the add-in automatically.

Additional useful commands:

- `npm run dev` - run only Vite dev server
- `npm run stop` - stop debugging/sideload session

Once you have HTTPS serving on `https://localhost:4200`, update `manifest.xml` if you change host/port.

### Office SSO setup (required)

1. Register an Azure app for your add-in.
2. Replace placeholders in `manifest.xml`:
   - `ov:WebApplicationInfo/ov:Id`
   - `ov:WebApplicationInfo/ov:Resource`
3. Add redirect URI(s) for your local/dev host.
4. Grant delegated permissions your add-in needs and grant admin consent if required.

### Enterprise deployment (no manual sideload per user)

For domain-wide rollout, use **Centralized Deployment** (Microsoft 365 admin center / Integrated Apps):

1. Build and host your add-in web app on Azure (for example Azure Static Web Apps or App Service).
2. Update `manifest.xml` URLs from localhost to your production HTTPS domain.
3. Upload/deploy the manifest through Microsoft 365 admin center to target groups/users.
4. Users get the add-in automatically in Excel, without manual sideloading.
