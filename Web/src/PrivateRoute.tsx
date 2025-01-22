import React from 'react';
import { Route, Navigate, RouteProps } from 'react-router-dom';
import { useAuth } from './auth-context';

interface PrivateRouteProps extends RouteProps {
    component: React.ComponentType<any>;
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({ component: Component, ...rest }) => {
    const { isAuthenticated } = useAuth();

    return (
        <Route
            {...rest}
            render={(props) =>
                isAuthenticated ? (
                    <Component {...props} />
                ) : (
                    <Navigate to="/login" />  // Redirect to login if not authenticated
                )
            }
        />
    );
};

export default PrivateRoute;
