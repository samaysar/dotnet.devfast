import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import * as devCerts from 'office-addin-dev-certs';

export default defineConfig(async () => {
  const httpsOptions = await devCerts.getHttpsServerOptions();

  return {
    plugins: [react()],
    server: {
      port: 4200,
      strictPort: true,
      https: httpsOptions,
    },
  };
});
