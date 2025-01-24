import React from 'react';
import { useAuth } from '../auth-context';
import { useNavigate } from 'react-router-dom';

const LogoutButton: React.FC = () => {
    const { logout } = useAuth();
    const navigation = useNavigate();

    const handleLogout = () => {
        logout();  // Clear token from context and localStorage
        navigation('/login');  // Redirect to login page
    };

    return <button onClick={handleLogout}>Logout</button>;
};

export default LogoutButton;
