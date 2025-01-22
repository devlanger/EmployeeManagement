import React, {useEffect, useState} from 'react';
import PieChartTest from '../Components/PieChartTest'
import Card from 'react-bootstrap/Card';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

interface SalaryStatistic {
    minSalary: number;
    maxSalary: number;
    amount: number;
}

const DashboardPage = () => {
    const [salaries, setSalaries] = useState<SalaryStatistic[]>();

    useEffect(() => {
        populateSalariesData();
    }, []);

    async function populateSalariesData() {
        const response = await fetch('api/Salary');
        const data = await response.json();
        console.log(data);
        setSalaries(data);
    }

    const content = salaries === undefined ? <p>Loading</p>
        : <PieChartTest data={salaries}></PieChartTest>;

    return (
        <div>
            <h1>Dashboard</h1>

            <Container>
                <Row>
                    <Col>
                        <Card>
                            <Card.Body>
                                <p>Employees Salary</p>
                                {content}
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col>
                        <Card>
                            <Card.Body>
                                <p>Employees Salary</p>
                                {content}
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
            </Container>
        </div>
    );
};

export default DashboardPage;
