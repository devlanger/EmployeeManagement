import Dropdown from 'react-bootstrap/Dropdown';
import axios from 'axios';
import * as React from "react";

interface ManageEmployeeDropdownProps {
    employeeId: string;
    refresh: () => void; // Callback to refresh employee list
}

const ManageEmployeeDropdown: React.FC<ManageEmployeeDropdownProps> = ({employeeId, refresh}) => {
    const handleGiveBonus = async () => {
        try {
            // Example API call
            const response = await axios.post('api/Salary/' + employeeId, {});

            if (response.status === 200) {
                await refresh();
            } else {
                alert('Failed to give bonus. Please try again.');
            }
        } catch (error) {
            console.error('Error giving bonus:', error);
            alert('An error occurred while giving the bonus.');
        }
    };

    return (
        <Dropdown>
            <Dropdown.Toggle variant="success" id="dropdown-basic">
                Actions
            </Dropdown.Toggle>

            <Dropdown.Menu>
                <Dropdown.Item onClick={() => handleGiveBonus(employeeId)}>Give bonus</Dropdown.Item>
                <Dropdown.Item href="#/action-2">Remove</Dropdown.Item>
            </Dropdown.Menu>
        </Dropdown>
    );
}

export default ManageEmployeeDropdown;