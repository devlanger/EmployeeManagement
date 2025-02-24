import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import axios from 'axios';
import { useAuth } from '../auth-context';

interface InputState {
    email: string;
    password: string;
    rememberMe: boolean;
}

const LoginPage: React.FC = () => {
    const location = useLocation();
    const navigate = useNavigate();
    const { login } = useAuth();

    const [input, setInput] = useState<InputState>({
        email: '',
        password: '',
        rememberMe: false
    });
    const [errorMessage, setErrorMessage] = useState<string>('');
    const [loading, setLoading] = useState<boolean>(false);
    const [autoSubmit, setAutoSubmit] = useState<boolean>(false);

    // Get return URL from query string
    let _returnUrl = new URLSearchParams(location.search).get('ReturnUrl') || '/';

    useEffect(() => {
        if (autoSubmit) {
            handleSubmit(new Event('submit') as unknown as React.FormEvent);
            setAutoSubmit(false);
        }
    }, [input]); // Triggered when `input` state updates

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value, type, checked } = e.target;
        setInput((prevState) => ({
            ...prevState,
            [name]: type === 'checkbox' ? checked : value
        }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');

        try {
            const response = await axios.post('/api/account/login', {
                email: input.email,
                password: input.password,
                rememberMe: input.rememberMe
            });

            if (response.data.token) {
                login(response.data.token);
                localStorage.setItem('authToken', response.data.token);
                navigate(_returnUrl);
            } else {
                setErrorMessage('Invalid login attempt.');
            }
        } catch (error) {
            console.error('Login failed:', error);
            setErrorMessage('Error: Invalid login attempt.');
        } finally {
            setLoading(false);
        }
    };

    const handleTestUserLogin = () => {
        setInput({
            email: 'admin@em.com',
            password: 'Test!123',
            rememberMe: false
        });

        setAutoSubmit(true); // Ensures submission happens only after state update
    };

    return (
        <div className="container">
            <div className="row">
                <div className="d-flex justify-content-center">
                    <section>
                        <h1>Login</h1>

                        {errorMessage && <div className="alert alert-danger">{errorMessage}</div>}
                        <form onSubmit={handleSubmit}>
                            <hr />
                            <div className="form-floating mb-3">
                                <input
                                    type="email"
                                    name="email"
                                    value={input.email}
                                    onChange={handleChange}
                                    className="form-control"
                                    placeholder="name@example.com"
                                    required
                                />
                                <label htmlFor="email" className="form-label">Email</label>
                            </div>
                            <div className="form-floating mb-3">
                                <input
                                    type="password"
                                    name="password"
                                    value={input.password}
                                    onChange={handleChange}
                                    className="form-control"
                                    placeholder="password"
                                    required
                                />
                                <label htmlFor="password" className="form-label">Password</label>
                            </div>
                            <div className="checkbox mb-3">
                                <label className="form-label">
                                    <input
                                        type="checkbox"
                                        name="rememberMe"
                                        checked={input.rememberMe}
                                        onChange={handleChange}
                                        className="form-check-input"
                                    />
                                    Remember me
                                </label>
                            </div>
                            <div>
                                <button type="submit" className="w-100 btn btn-lg btn-primary" disabled={loading}>
                                    {loading ? 'Logging in...' : 'Log in'}
                                </button>

                                <div className="mt-3">
                                    <button
                                        type="button"
                                        className="w-100 btn btn-secondary"
                                        onClick={handleTestUserLogin}
                                        disabled={loading}
                                    >
                                        {loading ? 'Logging in as Test User...' : 'Login as Test User'}
                                    </button>
                                </div>
                            </div>
                        </form>
                    </section>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
