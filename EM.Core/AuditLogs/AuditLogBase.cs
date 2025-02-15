using System.Text.Json.Serialization;
using EM.Core.Enums;

namespace EM.Core.AuditLogs;

public abstract class AuditLogBase
{
    [JsonIgnore]
    public abstract AuditLogType Type { get; }
}