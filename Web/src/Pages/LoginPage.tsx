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

    // Get return URL from query string
    const returnUrl = new URLSearchParams(location.search).get('ReturnUrl') || '/';

    useEffect(() => {
        // Clear any external cookies or session if needed (this is more relevant to server-side logic)
    }, []);

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
                // Redirect to the return URL or default if no ReturnUrl provided
                login(response.data.token);
                localStorage.setItem('authToken', response.data.token);
                navigate('/');
            } else {
                setErrorMessage('Invalid login attempt.' + response.data.token);
            }
        } catch (error) {
            console.error('Login failed:', error);
            setErrorMessage('Error: Invalid login attempt.');
        } finally {
            setLoading(false);
        }
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
                            </div>
                            <div>
                                <p>
                                    <a href="/Account/ForgotPassword">Forgot your password?</a>
                                </p>
                                <p>
                                    <a href={`/Account/Register?ReturnUrl=${encodeURIComponent(returnUrl)}`}>Register as a new user</a>
                                </p>
                                <p>
                                    <a href="/Account/ResendEmailConfirmation">Resend email confirmation</a>
                                </p>
                            </div>
                        </form>
                    </section>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
