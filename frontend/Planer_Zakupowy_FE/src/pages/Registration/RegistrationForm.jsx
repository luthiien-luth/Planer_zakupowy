import { useForm } from 'react-hook-form';
import { useMutation, useQueryClient } from 'react-query';
import axios from 'axios';

import { ErrorMessage } from '@hookform/error-message';

import TextInput from '@/components/TextInput';
import Layout from '@/components/Layout/Layout';
import { Button } from '@mui/material';

import { emailPattern } from '@/utils/emailUtils';

const API_URL = 'https://planerzakupowy.azurewebsites.net/';

export const RegistrationForm = () => {
    const {
        handleSubmit,
        control,
        getValues,
        trigger,
        formState: { errors }
    } = useForm({
        criteriaMode: 'all',
        defaultValues: {
            email: '',
            password: ''
        }
    });

    const queryClient = useQueryClient();

    const mutation = useMutation(
        async (data) => {
            const response = await axios.post(`${API_URL}/users/actions/register`, data);
            console.log('response.data', response.data);
            return response.data;
        },
        {
            onSuccess: () => {
                queryClient.invalidateQueries('userRegistrationData');
            },
            onError: (error) => {
                console.error('Error occurs:', error.message);
            }
        }
    );

    const handleRegistrationSubmit = async (formData) => {
        try {
            await mutation.mutateAsync(formData);
        } catch (error) {
            console.error('Error occurs:', error.message);
        }
    };

    const handleSubmitClick = async () => {
        const formData = getValues();

        try {
            const isValid = await trigger();

            if (isValid) {
                await handleRegistrationSubmit(formData);
            }
        } catch (error) {
            console.error('Error occurs during form submission:', error.message);
        }
    };

    return (
        <Layout>
            <form onSubmit={handleSubmit(handleSubmitClick)}>
                <div style={styles.container}>
                    <TextInput
                        control={control}
                        name="email"
                        type="email"
                        label="E-mail"
                        rules={{
                            required: 'This field is required',
                            minLength: {
                                value: 10,
                                message: 'Email must be at least 10 characters'
                            },
                            pattern: {
                                value: emailPattern,
                                message: 'Invalid email address'
                            }
                        }}
                        errors={errors.email}
                    />
                    <ErrorMessage
                        errors={errors}
                        name="email"
                        render={({ message }) => <p style={styles.errorMessage}>{message}</p>}
                    />

                    <TextInput
                        control={control}
                        name="password"
                        type="password"
                        label="Hasło"
                        rules={{
                            required: 'This field is required!',
                            minLength: {
                                value: 10,
                                message: 'Password must be at least 10 characters'
                            }
                        }}
                        errors={errors.password}
                    />
                    <ErrorMessage
                        errors={errors}
                        name="password"
                        render={({ message }) => <p style={styles.errorMessage}>{message}</p>}
                    />

                    <Button variant="contained" type="submit">
                        Wyślij
                    </Button>
                </div>
            </form>
        </Layout>
    );
};

const styles = {
    container: {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center'
    },
    errorMessage: {
        color: 'red'
    }
};
