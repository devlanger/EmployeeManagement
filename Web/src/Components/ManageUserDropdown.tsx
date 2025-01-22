import Dropdown from 'react-bootstrap/Dropdown';

function ManageUserDropdown() {
    return (
        <Dropdown>
            <Dropdown.Toggle variant="success" id="dropdown-basic">
                Actions
            </Dropdown.Toggle>

            <Dropdown.Menu>
                <Dropdown.Item href="#/action-1">Edit</Dropdown.Item>
                <Dropdown.Item href="#/action-2">Remove</Dropdown.Item>
            </Dropdown.Menu>
        </Dropdown>
    );
}

export default ManageUserDropdown;