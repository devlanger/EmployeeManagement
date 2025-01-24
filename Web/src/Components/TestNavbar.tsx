import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import {Button} from "react-bootstrap";
import { useAuth } from '../auth-context';
import LogoutButton from './LogoutButton';

function TestNavbar() {
    const { token } = useAuth();

    return (
        <Navbar className="bg-body-tertiary">
            <Container>
                <Navbar.Collapse className="justify-content-end">
                    <Navbar.Text className="px-3">
                        Signed in as: Admin
                    </Navbar.Text>
                    <LogoutButton />
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default TestNavbar;