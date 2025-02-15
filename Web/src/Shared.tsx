
export interface User {
    id: string;
    username: string;
    email: string;
    city: string;
    firstName: string;
    lastName: string;
    birthday: string;
    teamId: number | null;
    supervisorId: string | null;
}


export enum AuditLogType {
    USER_UPDATE = 1
}

export interface AuditLog {
    id: string;
    type: AuditLogType;
    data: string;
    createdDate: string;
}