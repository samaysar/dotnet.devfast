import { Button, Card, Text } from '@fluentui/react-components';
import './HomeFeature.css';

export function HomeFeature(props: { onOpenTest: () => void; onOpenLogin: () => void }) {
  return (
    <Card>
      <Text as="h2" weight="semibold" size={600}>
        Features
      </Text>
      <Text as="p">Use ribbon buttons from the SSS tab, or open features directly below.</Text>
      <div className="button-row">
        <Button appearance="primary" onClick={props.onOpenTest}>
          Test
        </Button>
        <Button appearance="primary" onClick={props.onOpenLogin}>
          Log In
        </Button>
      </div>
    </Card>
  );
}
