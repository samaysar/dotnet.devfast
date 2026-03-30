import { useEffect, useState } from 'react';
import { isOfficeHostAvailable } from './office/sso';
import { FluentProvider, teamsLightTheme } from '@fluentui/react-components';
import { HashRouter, Route, Routes, useNavigate } from 'react-router-dom';
import { HomeFeature } from './features/home/HomeFeature';
import { TestFeature } from './features/test/TestFeature';
import { LoginFeature } from './features/login/LoginFeature';
import { ErrorBoundary } from './ErrorBoundary';

type OfficeHost = Office.HostType | 'Unknown';

function HomeRoute() {
  const navigate = useNavigate();
  return (
    <HomeFeature onOpenTest={() => navigate('/test')} onOpenLogin={() => navigate('/login')} />
  );
}

export function App() {
  const [isOfficeReady, setIsOfficeReady] = useState(false);
  const [host, setHost] = useState<OfficeHost>('Unknown');
  const [isExcelHost, setIsExcelHost] = useState(false);
  const [runtimeError, setRuntimeError] = useState<string | null>(null);

  useEffect(() => {
    if (!isOfficeHostAvailable()) {
      return;
    }

    try {
      if (typeof Office.onReady === 'function') {
        Office.onReady((info) => {
          setIsOfficeReady(true);
          setHost(info.host || 'Unknown');
          setIsExcelHost(info.host === Office.HostType.Excel);
        });
      } else {
        setRuntimeError('Office.onReady is not available in this host.');
      }
    } catch (e) {
      const message = e instanceof Error ? e.message : String(e);
      setRuntimeError(`Office init failed: ${message}`);
    }
  }, []);

  useEffect(() => {
    // Ensure HashRouter starts in a known route if the WebView loads without a hash.
    if (window.location.hash === '') {
      window.location.hash = '#/';
    }

    const handleError = (event: ErrorEvent) => {
      setRuntimeError(event.message || 'Unknown runtime error');
    };
    const handleRejection = (event: PromiseRejectionEvent) => {
      setRuntimeError(String(event.reason ?? 'Unhandled promise rejection'));
    };

    window.addEventListener('error', handleError);
    window.addEventListener('unhandledrejection', handleRejection);

    return () => {
      window.removeEventListener('error', handleError);
      window.removeEventListener('unhandledrejection', handleRejection);
    };
  }, []);

  return (
    <FluentProvider theme={teamsLightTheme}>
      <HashRouter>
        <main className="shell">
          <header className="shell__header">
            <div>
              <h1>React Excel Add-in</h1>
              <p className="subtitle">
                Excel-only task pane with SSO using React + TypeScript + Vite
              </p>
            </div>
            <div className={`badge ${isOfficeReady ? 'badge--ready' : ''}`}>
              {isOfficeReady ? `Connected to ${host}` : 'Waiting for Office host...'}
            </div>
          </header>

          <ErrorBoundary>
            {runtimeError ? (
              <pre style={{ whiteSpace: 'pre-wrap', color: '#b91c1c', margin: 0 }}>
                Add-in runtime error:{'\n'}
                {runtimeError}
              </pre>
            ) : null}

            <Routes>
              <Route path="/" element={<HomeRoute />} />
              <Route path="/test" element={<TestFeature isExcelHost={isExcelHost} />} />
              <Route path="/login" element={<LoginFeature />} />
              <Route path="*" element={<HomeRoute />} />
            </Routes>
          </ErrorBoundary>
        </main>
      </HashRouter>
    </FluentProvider>
  );
}
