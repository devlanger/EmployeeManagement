import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";

const ManageUserPage = () => {
    const { userId } = useParams();
    const navigate = useNavigate();

    const [userDetails, setUserDetails] = useState({
        username: "",
        email: "",
        firstName: "",
        lastName: "",
        city: "",
        teamId: "",
        birthday: "",
        selectedRoles: [],
    });

    //const [allRoles, setAllRoles] = useState([]);
    const [stateMessage, setStateMessage] = useState("");

    // Fetch user and roles data
    useEffect(() => {
        const fetchData = async () => {
            try {
                const { data: userData } = await axios.get(`/api/user/${userId}`);
                //const { data: rolesData } = await axios.get("/api/roles");
                //const rolesData = ["Admin", "Manager", "Editor", "Viewer"];

                setUserDetails({
                    ...userData,
                    selectedRoles: userData.roles, // Assuming `roles` is part of the user data
                });
                //setAllRoles(rolesData);
            } catch (error) {
                console.error("Error fetching user data:", error);
            }
        };
        fetchData();
    }, [userId]);

    const handleInputChange = (e: { target: { name: any; value: any; }; }) => {
        const { name, value } = e.target;
        setUserDetails((prevDetails) => ({
            ...prevDetails,
            [name]: value,
        }));
    };

    //const handleRoleToggle = (role) => {
    //    setUserDetails((prevDetails) => {
    //        const isSelected = prevDetails.selectedRoles.includes(role);
    //        const updatedRoles = isSelected
    //            ? prevDetails.selectedRoles.filter((r) => r !== role)
    //            : [...prevDetails.selectedRoles, role];
    //        return { ...prevDetails, selectedRoles: updatedRoles };
    //    });
    //};

    const handleSubmit = async (e: { preventDefault: () => void; }) => {
        e.preventDefault();
        try {
            // Send all user details, including selectedRoles, to the update endpoint
            await axios.put(`/api/user/${userId}`, userDetails);
            setStateMessage("User updated successfully.");
        } catch (error) {
            console.error("Error updating user:", error);
            setStateMessage("An error occurred while updating the user.");
        }
    };

    const handleBack = () => {
        navigate("/users");
    };

    return (
        <div className="container">
            <button className="btn btn-primary mb-3" onClick={handleBack}>
                Back
            </button>
            <h1>Manage User {userId}</h1>
            {stateMessage && <div className="alert alert-success mt-3">{stateMessage}</div>}
            <form onSubmit={handleSubmit}>
                <h3>Personal Details</h3>
                <div className="form-group">
                    <label htmlFor="username">Name:</label>
                    <input
                        id="username"
                        name="username"
                        value={userDetails.username}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="email">Email:</label>
                    <input
                        id="email"
                        name="email"
                        value={userDetails.email}
                        onChange={handleInputChange}
                        type="email"
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="firstName">First name:</label>
                    <input
                        id="firstName"
                        name="firstName"
                        value={userDetails.firstName}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="lastName">Last name:</label>
                    <input
                        id="lastName"
                        name="lastName"
                        value={userDetails.lastName}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="city">City:</label>
                    <input
                        id="city"
                        name="city"
                        value={userDetails.city}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="teamId">Team Id:</label>
                    <input
                        id="teamId"
                        name="teamId"
                        value={userDetails.teamId}
                        onChange={handleInputChange}
                        type="number"
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="birthday">Birthdate:</label>
                    <input
                        id="birthday"
                        name="birthday"
                        value={userDetails.birthday}
                        onChange={handleInputChange}
                        type="date"
                        className="form-control"
                    />
                </div>
                <h3>Roles</h3>
                {/*{allRoles.map((role) => (
                    <div key={role} className="form-check">
                        <input
                            type="checkbox"
                            id={`role-${role}`}
                            checked={userDetails.selectedRoles.includes(role)}
                            onChange={() => handleRoleToggle(role)}
                            className="form-check-input"
                        />
                        <label htmlFor={`role-${role}`} className="form-check-label">
                            {role}
                        </label>
                    </div>
                ))}*/}
                <button type="submit" className="btn btn-primary mt-3">
                    Update
                </button>
            </form>
        </div>
    );
};

export default ManageUserPage;
