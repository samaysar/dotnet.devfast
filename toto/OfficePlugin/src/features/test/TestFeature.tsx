import { Button, Card, Text } from '@fluentui/react-components';
import { useCallback, useState } from 'react';

export function TestFeature(props: { isExcelHost: boolean }) {
  const [excelMessage, setExcelMessage] = useState('');
  const [error, setError] = useState('');

  const writeSampleData = useCallback(async () => {
    setError('');
    setExcelMessage('');

    if (!props.isExcelHost) {
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
  }, [props.isExcelHost]);

  return (
    <Card>
      <Text as="h2" weight="semibold" size={600}>
        Test
      </Text>
      <Text as="p">Writes sample text to your currently selected Excel cell.</Text>
      <Button appearance="primary" onClick={writeSampleData}>
        Write sample cell value
      </Button>
      {excelMessage ? <Text className="ok">{excelMessage}</Text> : null}
      {error ? <Text className="error">{error}</Text> : null}
    </Card>
  );
}
