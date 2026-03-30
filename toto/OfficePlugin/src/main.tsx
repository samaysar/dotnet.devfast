import React from 'react';
import ReactDOM from 'react-dom/client';
import { App } from './App';
import './styles.css';

const rootEl = document.getElementById('root');
if (!rootEl) {
  // Office WebView can sometimes load a different HTML shell; avoid silent blank panes.
  document.body.innerHTML =
    '<pre style="white-space:pre-wrap;color:#b91c1c;font-family:ui-monospace,SFMono-Regular,Menlo,Monaco,Consolas,monospace">Add-in failed: missing #root element.</pre>';
} else {
  try {
    ReactDOM.createRoot(rootEl).render(<App />);
  } catch (e) {
    const message = e instanceof Error ? e.message : String(e);
    rootEl.innerHTML =
      '<pre style="white-space:pre-wrap;color:#b91c1c;margin:0;padding:12px;font-family:ui-monospace,SFMono-Regular,Menlo,Monaco,Consolas,monospace">Add-in bootstrap failed:\n' +
      message +
      '</pre>';
  }
}
