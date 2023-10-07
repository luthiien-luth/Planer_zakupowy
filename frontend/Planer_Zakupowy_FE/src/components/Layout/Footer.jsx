import { Box } from '@mui/material';
import themes from '@/themes/themes';

function Footer() {
    return (
        <Box
            sx={{
                position: 'fixed',
                width: '100%',
                height: '3rem',
                backgroundColor: themes.color.secondary,
                bottom: 0,
                left: 0
            }}
        />
    );
}

export default Footer;
