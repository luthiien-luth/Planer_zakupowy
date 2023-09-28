import Typography from '@mui/material/Typography';

export function Header({ title }) {
    return (
        <Typography variant="h1" gutterBottom>
            {title}
        </Typography>
    );
}
