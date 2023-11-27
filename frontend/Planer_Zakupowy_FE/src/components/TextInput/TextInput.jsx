import { Controller } from 'react-hook-form';

//components MUI
import { TextField, Box } from '@mui/material';

export const TextInput = ({ control, name, defaultValue, rules, id, label, type }) => {
    return (
        <Box
            sx={{
                width: '340px',
                margin: '16px'
            }}>
            <Controller
                control={control}
                name={name}
                defaultValue={defaultValue}
                rules={rules}
                render={({ field: { onChange } }) => (
                    <>
                        <TextField
                            variant="outlined"
                            onChange={onChange}
                            id={id}
                            label={label}
                            type={type}
                        />
                    </>
                )}
            />
        </Box>
    );
};
