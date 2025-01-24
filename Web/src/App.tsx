import './App.css';
import {BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import DashboardPage from './Pages/DashboardPage';
import EmployeesPage from './Pages/EmployeesPage';
import ManageUserPage from './Pages/ManageUserPage';
import TeamsPage from './Pages/TeamsPage';
import LoginPage from './Pages/LoginPage';
import 'bootstrap/dist/css/bootstrap.min.css';
import {AuthProvider} from "./auth-context";
import PrivateRoute from './PrivateRoute';
import UsersPage from "./Pages/UsersPage";

function App() {
    return (
        <AuthProvider>
            <Router>
                <Routes>
                    <Route path="/login" element={<LoginPage />} />
                    <Route path="/" element={<PrivateRoute component={DashboardPage} />}/>
                    <Route path="/employees" element={<PrivateRoute component={EmployeesPage} />}/>
                    <Route path="/teams" element={<PrivateRoute component={TeamsPage} />}/>
                    <Route path="/users" element={<PrivateRoute component={UsersPage} />}/>
                    <Route path="/users/:userId" element={<PrivateRoute component={ManageUserPage} />} />
                    <Route path="*" element={<Navigate to="/login" />} />
                </Routes>
            </Router>
        </AuthProvider>
    );
}

export default App;