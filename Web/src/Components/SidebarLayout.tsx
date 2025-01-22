import React from 'react';
import { Container, Row, Col, Nav } from 'react-bootstrap';

const SidebarLayout = ({children}) => {
    return (
        <Container fluid className="vh-100">
            <Row>
                <Col xs={3} className="bg-dark text-white p-3" style={{ height: '100vh' }}>
                    <h4>Sidebar</h4>
                    <Nav defaultActiveKey="/" className="flex-column">
                        <Nav.Link href="/dashboard">Dashboard</Nav.Link>
                        <Nav.Link href="/Employees">Employees</Nav.Link>
                        <Nav.Link href="/Teams">Teams</Nav.Link>
                    </Nav>
                </Col>
                <Col xs={9} className="p-4">
                    {children}
                </Col>
            </Row>
        </Container>
    );
};

export default SidebarLayout;
