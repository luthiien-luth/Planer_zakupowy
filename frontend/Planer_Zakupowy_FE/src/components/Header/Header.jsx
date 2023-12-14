import Typography from '@mui/material/Typography';
import { AppBar } from '@mui/material';
import themes from '@/themes/themes';

export function Header({ title }) {
    return (
        <>
            <AppBar
                position="fixed"
                color="primary"
                sx={{
                    backgroundColor: themes.color.secondary,
                    height: '5rem'
                }}
            />
            <div
                style={{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    height: '50vh'
                }}>
                <Typography variant="h2" gutterBottom>
                    {title}
                </Typography>
            </div>
        </>
    );
}
