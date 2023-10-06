import Button from '@mui/material/Button';

const ButtonWrapper = ({ variant, color, size, onClick, children, ...rest }) => {
    return (
        <Button variant={variant} color={color} size={size} onClick={onClick} {...rest}>
            {children}
        </Button>
    );
};

export default ButtonWrapper;
