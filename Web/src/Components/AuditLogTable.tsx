import React, { useEffect, useState } from "react";
import { AuditLog } from "../Shared.tsx";
import axios from "axios";

interface AuditLogTableProps {
    userId?: any;
}

const AuditLogTable: React.FC<AuditLogTableProps> = ({ userId }) => {
    const [auditLogs, setAuditLogs] = useState<AuditLog[]>([]);

    useEffect(() => {
        const fetchLogs = async () => {
            try {
                const { data: auditLogs } = await axios.get(`/api/auditlogs?type=1&entityId=${userId}`);
                console.log(auditLogs);
                setAuditLogs(auditLogs);
            } catch (error) {
                console.error("Failed to fetch audit logs", error);
            }
        };

        fetchLogs();
    }, [userId]); // Dependency array ensures effect runs when userId changes

    return (
        <div>
            <h3>Audit Logs</h3>
            <table>
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Action</th>
                    <th>Date</th>
                </tr>
                </thead>
                <tbody>
                {auditLogs.map((log) => (
                    <tr key={log.id}>
                        <td>{log.id}</td>
                        <td>{log.data}</td>
                        <td>{new Date(log.createdDate).toLocaleString()}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
};

export default AuditLogTable;