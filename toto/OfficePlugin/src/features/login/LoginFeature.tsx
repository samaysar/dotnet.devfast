import { Button, Card, Text } from '@fluentui/react-components';
import { useCallback, useState } from 'react';
import { getOfficeSsoToken, isOfficeHostAvailable } from '../../office/sso';

export function LoginFeature() {
  const [tokenPreview, setTokenPreview] = useState('');
  const [error, setError] = useState('');

  const requestSsoToken = useCallback(async () => {
    setError('');
    setTokenPreview('');

    if (!isOfficeHostAvailable()) {
      setError('Office host is not available.');
      return;
    }

    try {
      const token = await getOfficeSsoToken();
      setTokenPreview(`${token.slice(0, 20)}...${token.slice(-12)}`);
    } catch (ssoError) {
      setError(ssoError instanceof Error ? ssoError.message : 'Failed to get Office SSO token.');
    }
  }, []);

  return (
    <Card>
      <Text as="h2" weight="semibold" size={600}>
        Log In
      </Text>
      <Text as="p">Request an Office SSO access token for the signed-in Excel user.</Text>
      <Button appearance="primary" onClick={requestSsoToken}>
        Get SSO token
      </Button>
      {tokenPreview ? <Text className="ok">Token preview: {tokenPreview}</Text> : null}
      {error ? <Text className="error">{error}</Text> : null}
    </Card>
  );
}
