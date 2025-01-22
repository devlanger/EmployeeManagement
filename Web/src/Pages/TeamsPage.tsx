import React, {useEffect, useState} from 'react';

interface Employee {
    id: number;
    name: string;
    membersCount: number;
}

const TeamsPage = () => {
    const [teams, setTeams] = useState<Team[]>();

    useEffect(() => {
        populateTeamsData();
    }, []);

    const contents = teams === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Members Count</th>
            </tr>
            </thead>
            <tbody>
            {teams.map(team =>
                <tr key={team.id}>
                    <td>{team.id}</td>
                    <td>{team.name}</td>
                    <td>{team.membersCount}</td>
                </tr>
            )}
            </tbody>
        </table>;

    async function populateTeamsData() {
        const response = await fetch('http://localhost:5054/api/team');
        const data = await response.json();
        console.log(data);
        setTeams(data);
    }

    return (
        <div>
            <h1 id="tableLabel">Teams</h1>
            {contents}
        </div>
    );
};

export default TeamsPage;
