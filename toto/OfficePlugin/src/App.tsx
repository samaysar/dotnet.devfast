import { useCallback, useEffect, useState } from 'react';
import { getOfficeSsoToken, isOfficeHostAvailable } from './office/sso';

type OfficeHost = Office.HostType | 'Unknown';

export function App() {
  const [isOfficeReady, setIsOfficeReady] = useState(false);
  const [host, setHost] = useState<OfficeHost>('Unknown');
  const [tokenPreview, setTokenPreview] = useState('');
  const [error, setError] = useState('');

  useEffect(() => {
    if (!isOfficeHostAvailable()) {
      return;
    }

    Office.onReady((info) => {
      setIsOfficeReady(true);
      setHost(info.host || 'Unknown');
    });
  }, []);

  const requestSsoToken = useCallback(async () => {
    setError('');

    try {
      const token = await getOfficeSsoToken();
      setTokenPreview(`${token.slice(0, 20)}...${token.slice(-12)}`);
    } catch (ssoError) {
      setTokenPreview('');
      setError(ssoError instanceof Error ? ssoError.message : 'Failed to get Office SSO token.');
    }
  }, []);

  return (
    <main className="shell">
      <header className="shell__header">
        <div>
          <h1>React Office Add-in</h1>
          <p className="subtitle">SSO-ready task pane using React + TypeScript + Vite</p>
        </div>
        <div className={`badge ${isOfficeReady ? 'badge--ready' : ''}`}>
          {isOfficeReady ? `Connected to ${host}` : 'Waiting for Office host...'}
        </div>
      </header>

      <section className="card">
        <h2>Microsoft Identity SSO</h2>
        <p>Click to request an Office SSO access token for the signed-in user.</p>
        <button type="button" onClick={requestSsoToken}>
          Get SSO token
        </button>
        {tokenPreview ? <p className="ok">Token preview: {tokenPreview}</p> : null}
        {error ? <p className="error">{error}</p> : null}
      </section>
    </main>
  );
}
