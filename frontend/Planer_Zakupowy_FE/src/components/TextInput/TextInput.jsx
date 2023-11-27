import { Controller } from 'react-hook-form';

//components MUI
import TextField from '@mui/material/TextField';

export const TextInput = ({ formControl, label, rules }) => {
    return (
        <Controller
            control={formControl}
            name={name}
            rules={('require', rules)}
            render={() => (
                <TextField id="outlined-basic" label={label} variant="outlined" style={styles} />
            )}
        />
    );
};

const styles = {
    width: 340,
    margin: 10
};
