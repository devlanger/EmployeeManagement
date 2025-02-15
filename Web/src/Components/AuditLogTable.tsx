import React, { useEffect, useState } from "react";
import {AuditLog, AuditLogType} from "../Shared.tsx";
import axios from "axios";

interface AuditLogTableProps {
    type?: any;
    userId?: any;
}

const AuditLogTable: React.FC<AuditLogTableProps> = ({ userId, type }) => {
    const [auditLogs, setAuditLogs] = useState<AuditLog[]>([]);
    
    function getAuditLogTypeName(value: number): string | undefined {
        return Object.keys(AuditLogType).find(key => AuditLogType[key as keyof typeof AuditLogType] === value);
    }
    
    useEffect(() => {
        
        const fetchLogs = async () => {
            try {
                let url = "/api/auditlogs";
                const params = new URLSearchParams();

                if (type !== undefined && type !== null) {
                    params.append("type", type);
                }
                if (userId !== undefined && userId !== null) {
                    params.append("entityId", userId);
                }

                const fullUrl = params.toString() ? `${url}?${params.toString()}` : url;

                const { data: auditLogs } = await axios.get(fullUrl);
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
                    <th>Type</th>
                    <th>Data</th>
                    <th>Created Date</th>
                </tr>
                </thead>
                <tbody>
                {auditLogs.map((log) => (
                    <tr key={log.id}>
                        <td>{log.id}</td>
                        <td>{getAuditLogTypeName(log.type)}</td>
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