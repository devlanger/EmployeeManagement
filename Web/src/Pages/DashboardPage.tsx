import {useEffect, useState} from 'react';
import Card from 'react-bootstrap/Card';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import TeamSizePieChart from "../Components/TeamSizePieChart.tsx";
import SalariesBarChart from "../Components/SalariesBarChart.tsx";

interface SalaryStatistic {
    minSalary: number;
    maxSalary: number;
    amount: number;
}

interface TeamSizeStatistic {
    id: number;
    name: string;
    membersCount: number;
}

const DashboardPage = () => {
    const [salaries, setSalaries] = useState<SalaryStatistic[]>([]);
    const [teams, setTeams] = useState<TeamSizeStatistic[]>([]);

    useEffect(() => {
        populateSalariesData();
        populateTeamsData();
    }, []);

    async function populateSalariesData() {
        const response = await fetch('api/Salary');
        const data = await response.json();
        console.log(data);
        setSalaries(data);
    }
    
    async function populateTeamsData() {
        const response = await fetch('api/Team');
        const data = await response.json();
        console.log(data);
        setTeams(data);
    }

    const salariesContent = salaries === undefined ? <p>Loading</p>
        : <SalariesBarChart data={salaries}></SalariesBarChart>;

    const teamsContent = salaries === undefined ? <p>Loading</p>
        : <TeamSizePieChart data={teams}></TeamSizePieChart>;
    
    return (
        <div>
            <h1>Dashboard</h1>

            <Container>
                <Row>
                    <Col>
                        <Card>
                            <Card.Body>
                                <p>Employees Salary Chart</p>
                                {salariesContent}
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col>
                        <Card>
                            <Card.Body>
                                <p>Teams Size Chart</p>
                                {teamsContent}
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
            </Container>
        </div>
    );
};

export default DashboardPage;
