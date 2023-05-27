import React, { useState } from 'react';
import './styles.css';
import Accept from '../Button/accept';
import { Card, CardContent, Typography, TextField, Select, MenuItem, CircularProgress } from '@mui/material';

const CustomCard = () => {

  const [proposal, setProposal] = useState({ creditAmount: 0, type: 1, installments: 0, firstDueDate: "2023-05-26" });
  const [response, setResponse] = useState();
  const [creditAmountFormated, setCreditAmountFormated] = useState();
  const [creditAmountNotFormated, setCreditAmountNotFormated] = useState();
  const [isLoading, setIsLoading] = React.useState(false);

  React.useEffect(() => {

    var value = creditAmountNotFormated + '';
    value = parseInt(value.replace(/[\D]+/g, ''));
    value = value + '';
    value = value.replace(/([0-9]{2})$/g, ",$1");

    if (value.length > 6) {
      value = value.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");
    }

    if (value === 'NaN') value = '';

    setCreditAmountFormated(value);

    let removeThousand = value.replace(/[.]/g, '');

    let newValue = removeThousand.replace(/[,]/g, '.');

    setProposal({ ...proposal, creditAmount: newValue });

  }, [creditAmountNotFormated]);

  const handleChangeType = (event) => {
    setProposal({ ...proposal, type: event.target.value });
  };

  const handleChangeInstallments = (event) => {
    setProposal({ ...proposal, installments: event.target.value });
  };

  async function handleLSendProposal() {

    setIsLoading(true);

    console.log(response)

    const requestInfo = {
      method: 'POST',
      headers: new Headers({
        'Content-Type': 'application/json'
      }),
      body: JSON.stringify(proposal)
    };

    console.log(JSON.stringify(proposal))

    await fetch(process.env.REACT_APP_BASE_URL + '/credit/validate', requestInfo)
      .then(response => {
        return response.json();
      })
      .then((json) => {
        setResponse(json);
        setIsLoading(false);
      })
      .catch((error) => {
        alert('Sistema indisponível.');
      });
  }

  return (
    <Card className="card">
      <CardContent sx={{ width: '60%' }}>
        <Typography variant="h6">Valor do crédito*:</Typography>
        <TextField
          sx={{ mb: 2 }}
          value={creditAmountFormated}
          onChange={e => setCreditAmountNotFormated(e.target.value)}
        />
        <Typography variant="h6">Tipo de crédito*:</Typography>
        <Select fullWidth
          labelId="select-label"
          sx={{ mb: 2 }}
          value={proposal.type}
          onChange={handleChangeType}
        >
          <MenuItem value={1}>Crédito Direto</MenuItem>
          <MenuItem value={2}>Crédito Consignado</MenuItem>
          <MenuItem value={3}>Crédito Pessoa Jurídica</MenuItem>
          <MenuItem value={4}>Crédito Pessoa Física</MenuItem>
          <MenuItem value={5}>Crédito Imobiliário</MenuItem>
        </Select>
        <Typography variant="h6">Quantidade de parcelas*:</Typography>
        <TextField sx={{ mb: 2 }}
          fullWidth
          value={proposal.installments}
          onChange={e => handleChangeInstallments(e)} />
        <Typography variant="h6">Data do primeiro vencimento*:</Typography>
        <TextField
          fullWidth
          type="date"
          value={proposal.firstDueDate}
          onChange={e => setProposal({ ...proposal, firstDueDate: e.target.value })} />
        <Accept
          className="btn-button"
          variant="contained"
          type="button"
          onClick={handleLSendProposal}
        >
          Enviar análise
          {isLoading ? (
            <CircularProgress
              color="inherit"
              size="1rem"
              sx={{ marginLeft: 2 }}
            />
          ) : (
            <></>
          )}
        </Accept>
        {response?.isApproved !== undefined && (
          <Typography variant="body1" sx={{ marginTop: 2 }}>
            {response.isApproved}
          </Typography>
        )}
      </CardContent>
    </Card>
  );
};

export default CustomCard;
