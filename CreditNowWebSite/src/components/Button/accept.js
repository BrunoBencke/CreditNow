import { Button } from '@mui/material';
import { styled } from '@mui/material/styles';

const Accept = styled(Button)(({ theme }) => ({
  color: '#FFFFFF',
  marginTop: '20px',
  backgroundColor: '#0E1C41',
  '&:hover': {
    backgroundColor: '#21345B',
    color: '#FFFFFF',
  },
}));

export default Accept;
