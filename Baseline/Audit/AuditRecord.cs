using System.ComponentModel.DataAnnotations;
using ITI.DDD.Core;
using Microsoft.EntityFrameworkCore;

namespace ITI.Baseline.Audit;

/// <summary>
/// Make sure to call OnModelCreating to create an important index.
/// </summary>
public class AuditRecord
{
    public AuditRecord(
        string? userId,
        string? userName,
        string aggregate,
        string aggregateId,
        string entity,
        string entityId,
        string @event,
        string changes
    )
    {
        WhenUtc = DateTimeOffset.UtcNow;
        UserId = userId;
        UserName = userName?.MaxLength(64);
        Aggregate = aggregate.MaxLength(64);
        AggregateId = aggregateId;
        Entity = entity.MaxLength(64);
        EntityId = entityId;
        Event = @event;
        Changes = changes;
    }

    public long Id { get; protected set; }

    public DateTimeOffset WhenUtc { get; protected set; }

    [MaxLength(64)]
    public string? UserId { get; protected set; }

    [MaxLength(64)]
    public string? UserName { get; protected set; }

    [MaxLength(64)]
    public string Aggregate { get; protected set; }

    [MaxLength(64)]
    public string AggregateId { get; protected set; }

    [MaxLength(64)]
    public string Entity { get; protected set; }

    [MaxLength(64)]
    public string EntityId { get; protected set; }

    [MaxLength(64)]
    public string Event { get; protected set; }

    public string Changes { get; protected set; }

    public static void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<AuditRecord>()
            .HasIndex(p => new { p.Entity, p.EntityId });

        mb.Entity<AuditRecord>()
            .HasIndex(p => new { p.Aggregate, p.AggregateId });
    }
}
