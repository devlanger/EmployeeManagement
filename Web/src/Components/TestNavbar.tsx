import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import LogoutButton from './LogoutButton';

function TestNavbar() {
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