import React from 'react';
import {Container, Row, Col, Nav} from 'react-bootstrap';

const SidebarLayout = ({children}) => {
    return (
        <Container fluid className="vh-100">
            <Row>
                <Col xs={2} className="bg-dark text-white p-3" style={{height: '100vh'}}>
                    <h4><a href="/">ERP</a></h4>
                    <Nav defaultActiveKey="/" className="flex-column">
                        <Nav.Link href="/">Dashboard</Nav.Link>
                        <Nav.Link href="/Employees">Employees</Nav.Link>
                        <Nav.Link href="/Teams">Teams</Nav.Link>
                    </Nav>
                </Col>
                <Col className="p-0">
                    {children}
                </Col>
            </Row>
        </Container>
    );
};

export default SidebarLayout;
