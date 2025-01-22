import React from 'react';
import { useAuth } from './auth-context';
import { useHistory } from 'react-router-dom';

const LogoutButton: React.FC = () => {
    const { logout } = useAuth();
    const history = useHistory();

    const handleLogout = () => {
        logout();  // Clear token from context and localStorage
        history.push('/login');  // Redirect to login page
    };

    return <button onClick={handleLogout}>Logout</button>;
};

export default LogoutButton;
