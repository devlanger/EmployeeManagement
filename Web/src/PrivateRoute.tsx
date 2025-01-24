import React from 'react';
import {Navigate} from 'react-router-dom';
import {useAuth} from './auth-context';
import TestNavbar from './Components/TestNavbar';
import SidebarLayout from './Components/SidebarLayout';
import Container from 'react-bootstrap/Container';

interface PrivateRouteProps {
    component: React.ElementType;
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({component: Component}) => {
    const {isAuthenticated} = useAuth();

    console.log(isAuthenticated);
    if (!isAuthenticated) {
        return <Navigate to="/login" replace/>;

    }

    return (<SidebarLayout>
                <TestNavbar></TestNavbar>
                <Container>
                    <Component></Component>
                </Container>
            </SidebarLayout>);
};

export default PrivateRoute;
