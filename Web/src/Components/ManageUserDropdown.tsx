import Dropdown from 'react-bootstrap/Dropdown';
import axios from 'axios';
import * as React from "react";

interface ManageUserDropdownProps {
    userId: string;
}

const ManageUserDropdown: React.FC<ManageUserDropdownProps> = ({userId}) => {
    return (
        <Dropdown>
            <Dropdown.Toggle variant="success" id="dropdown-basic">
                Actions
            </Dropdown.Toggle>

            <Dropdown.Menu>
                <Dropdown.Item href={`/users/${userId}`}>Manage</Dropdown.Item>
            </Dropdown.Menu>
        </Dropdown>
    );
}

export default ManageUserDropdown;