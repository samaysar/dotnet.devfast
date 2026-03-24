import { useCallback, useEffect, useState } from 'react';
import { getOfficeSsoToken, isOfficeHostAvailable } from './office/sso';

type OfficeHost = Office.HostType | 'Unknown';
type FeatureRoute = 'home' | 'write' | 'sso';

function getFeatureRouteFromHash(hash: string): FeatureRoute {
  if (hash === '#/write') return 'write';
  if (hash === '#/sso') return 'sso';
  return 'home';
}

export function App() {
  const [isOfficeReady, setIsOfficeReady] = useState(false);
  const [host, setHost] = useState<OfficeHost>('Unknown');
  const [isExcelHost, setIsExcelHost] = useState(false);
  const [activeFeature, setActiveFeature] = useState<FeatureRoute>(() =>
    getFeatureRouteFromHash(window.location.hash)
  );
  const [tokenPreview, setTokenPreview] = useState('');
  const [error, setError] = useState('');
  const [excelMessage, setExcelMessage] = useState('');

  useEffect(() => {
    const onHashChange = () => setActiveFeature(getFeatureRouteFromHash(window.location.hash));
    window.addEventListener('hashchange', onHashChange);
    return () => window.removeEventListener('hashchange', onHashChange);
  }, []);

  useEffect(() => {
    if (!isOfficeHostAvailable()) {
      return;
    }

    Office.onReady((info) => {
      setIsOfficeReady(true);
      setHost(info.host || 'Unknown');
      setIsExcelHost(info.host === Office.HostType.Excel);
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

  const writeSampleData = useCallback(async () => {
    setError('');
    setExcelMessage('');

    if (!isExcelHost) {
      setError('This add-in is configured for Excel only. Please open it from Excel.');
      return;
    }

    try {
      await Excel.run(async (context) => {
        const range = context.workbook.getSelectedRange();
        range.values = [['React Excel Add-in']];
        range.format.fill.color = '#D1FAE5';
        range.format.font.bold = true;
        await context.sync();
      });
      setExcelMessage('Wrote sample data to selected cell.');
    } catch (excelError) {
      setError(excelError instanceof Error ? excelError.message : 'Failed to write Excel data.');
    }
  }, [isExcelHost]);

  return (
    <main className="shell">
      <header className="shell__header">
        <div>
          <h1>React Excel Add-in</h1>
          <p className="subtitle">Excel-only task pane with SSO using React + TypeScript + Vite</p>
        </div>
        <div className={`badge ${isOfficeReady ? 'badge--ready' : ''}`}>
          {isOfficeReady ? `Connected to ${host}` : 'Waiting for Office host...'}
        </div>
      </header>

      {activeFeature === 'home' ? (
        <section className="card">
          <h2>Features</h2>
          <p>Use ribbon buttons from the SSS tab, or open features directly below.</p>
          <div className="button-row">
            <button type="button" onClick={() => (window.location.hash = '#/write')}>
              Test
            </button>
            <button type="button" onClick={() => (window.location.hash = '#/sso')}>
              Log In
            </button>
          </div>
        </section>
      ) : null}

      {activeFeature === 'write' ? (
        <section className="card">
          <h2>Test</h2>
          <p>Writes sample text to your currently selected Excel cell.</p>
          <button type="button" onClick={writeSampleData}>
            Write sample cell value
          </button>
          {excelMessage ? <p className="ok">{excelMessage}</p> : null}
        </section>
      ) : null}

      {activeFeature === 'sso' ? (
        <section className="card">
          <h2>Log In</h2>
          <p>Request an Office SSO access token for the signed-in Excel user.</p>
          <button type="button" onClick={requestSsoToken}>
            Get SSO token
          </button>
          {tokenPreview ? <p className="ok">Token preview: {tokenPreview}</p> : null}
        </section>
      ) : null}

      {error ? <p className="error">{error}</p> : null}
    </main>
  );
}
