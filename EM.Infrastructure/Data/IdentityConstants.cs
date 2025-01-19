namespace EM.Infrastructure.Data;

public class IdentityConstants
{
    public const string ADMIN_ROLE_NAME = "Admin";
    public const string EMPLOYEE_ROLE_NAME = "User";
    public const string ROLES_MANAGE_ROLE_NAME = "Manage Roles";
    public const string TEAMS_VIEW_ROLE_NAME = "View Teams";
    public const string TEAMS_MANAGE_ROLE_NAME = "Manage Teams";
    public const string USERS_VIEW_ROLE_NAME = "View Users";
    public const string USERS_MANAGE_ROLE_NAME = "Manage Users";

    public static IEnumerable<string> AllRoles => new[]
    {
        ADMIN_ROLE_NAME,
        EMPLOYEE_ROLE_NAME,
        ROLES_MANAGE_ROLE_NAME,
        TEAMS_VIEW_ROLE_NAME,
        TEAMS_MANAGE_ROLE_NAME,
        USERS_VIEW_ROLE_NAME,
        USERS_MANAGE_ROLE_NAME,
    };
}