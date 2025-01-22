import {useEffect, useState} from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import TestNavbar from './Components/TestNavbar';
import SidebarLayout from './Components/SidebarLayout';
import DashboardPage from './Pages/DashboardPage';
import EmployeesPage from './Pages/EmployeesPage';
import TeamsPage from './Pages/TeamsPage';
import 'bootstrap/dist/css/bootstrap.min.css';


function App() {
    return (
        <Router>
            <SidebarLayout>
                <Routes>
                    <Route path="/dashboard" element={<DashboardPage />} />
                    <Route path="/employees" element={<EmployeesPage />} />
                    <Route path="/teams" element={<TeamsPage />} />
                </Routes>
            </SidebarLayout>
        </Router>
    );
}

export default App;