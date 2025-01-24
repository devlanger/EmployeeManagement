import React from 'react';
import {useEffect, useState} from 'react';
import ManageEmployeeDropdown from "../Components/ManageEmployeeDropdown";

interface Employee {
    id: string;
    firstName: string;
    lastName: string;
    salary: string;
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
                <th>First Name</th>
                <th>Last Name</th>
                <th>Salary</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            {employees.map(employee =>
                <tr key={employee.id}>
                    <td>{employee.id}</td>
                    <td>{employee.firstName}</td>
                    <td>{employee.lastName}</td>
                    <td>{employee.salary}</td>
                    <td>
                        <ManageEmployeeDropdown 
                            employeeId={employee.id}
                            refresh={populateEmployeesData}/>
                    </td>
                </tr>
            )}
            </tbody>
        </table>;

    async function populateEmployeesData() {
        const response = await fetch('api/user');
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
