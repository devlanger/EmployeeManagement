import {useEffect, useState} from 'react';
import ManageUserDropdown from '../Components/ManageUserDropdown';

interface User {
    id: string;
    firstName: string;
    lastName: string;
}

const UsersPage = () => {
    const [users, setUsers] = useState<User[]>();

    useEffect(() => {
        populateUsersData();
    }, []);

    const contents = users === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
            <tr>
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            {users.map(user =>
                <tr key={user.id}>
                    <td>{user.id}</td>
                    <td>{user.firstName}</td>
                    <td>{user.lastName}</td>
                    <td>
                        <ManageUserDropdown 
                            userId={user.id}/>
                    </td>
                </tr>
            )}
            </tbody>
        </table>;

    async function populateUsersData() {
        const response = await fetch('api/user');
        const data = await response.json();
        console.log(data);
        setUsers(data);
    }
    
    return (
        <div>
            <h1 id="tableLabel">Users</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
};

export default UsersPage;
