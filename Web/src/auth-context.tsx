import React, { createContext, useState, useContext, ReactNode } from 'react';

// Interface for the authentication context
interface AuthContextType {
    isAuthenticated: boolean;
    login: (token: string) => void;
    logout: () => void;
    token: string | null;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error('useAuth must be used within an AuthProvider');
    }
    return context;
};

interface AuthProviderProps {
    children: ReactNode;
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
    const [token, setToken] = useState<string | null>(localStorage.getItem('authToken'));

    const login = (newToken: string) => {
        setToken(newToken);
        localStorage.setItem('authToken', newToken); // Store the token in localStorage
    };

    const logout = () => {
        setToken(null);
        localStorage.removeItem('authToken'); // Remove the token from localStorage
    };

    return (
        <AuthContext.Provider value={{ isAuthenticated: !!token, login, logout, token }}>
            {children}
        </AuthContext.Provider>
    );
};
