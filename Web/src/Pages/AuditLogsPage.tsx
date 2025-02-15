import React from 'react';
import AuditLogTable from "../Components/AuditLogTable.tsx";

const AuditLogsPage = () => {
    return (
        <div>
            <h1 id="tableLabel">Audit Logs</h1>
            <AuditLogTable />
        </div>
    );
};

export default AuditLogsPage;
