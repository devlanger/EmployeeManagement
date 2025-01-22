import React from 'react';
import {useEffect, useState} from 'react';
import ManageUserDropdown from '../Components/ManageUserDropdown';

interface Employee {
    id: string;
    firstName: string;
    lastName: string;
}

const EmployeesPage = () => {
    const [employees, setEmployees] = useState<Employee[]>();

    useEffect(() => {
        populateEmployeesData();
    }, []);

    const contents = employees === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
            <tr>
                <th>Id</th>
                <th>Username</th>
                <th>First Name</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            {employees.map(employee =>
                <tr key={employee.id}>
                    <td>{employee.id}</td>
                    <td>{employee.firstName}</td>
                    <td>{employee.lastName}</td>
                    <td>
                        <ManageUserDropdown>

                        </ManageUserDropdown>
                    </td>
                </tr>
            )}
            </tbody>
        </table>;

    async function populateEmployeesData() {
        const response = await fetch('http://localhost:5054/api/user');
        const data = await response.json();
        console.log(data);
        setEmployees(data);
    }
    
    return (
        <div>
            <h1 id="tableLabel">Employees</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
};

export default EmployeesPage;
