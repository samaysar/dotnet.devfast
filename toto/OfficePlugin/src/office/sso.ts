declare const OfficeRuntime: {
  auth: {
    getAccessToken(options?: {
      allowSignInPrompt?: boolean;
      allowConsentPrompt?: boolean;
    }): Promise<string>;
  };
};

export function isOfficeHostAvailable(): boolean {
  return typeof Office !== 'undefined';
}

export async function getOfficeSsoToken(): Promise<string> {
  if (!isOfficeHostAvailable() || typeof OfficeRuntime === 'undefined') {
    throw new Error(
      'Office host is not available. Run inside Word/Excel with sideloaded manifest and HTTPS.'
    );
  }

  try {
    return await OfficeRuntime.auth.getAccessToken({
      allowSignInPrompt: true,
      allowConsentPrompt: true,
    });
  } catch (error) {
    const message = error instanceof Error ? error.message : String(error);
    throw new Error(`Office SSO token request failed: ${message}`);
  }
}
