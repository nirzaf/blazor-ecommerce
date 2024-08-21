namespace BlazorEcommerce.Domain.Common;

public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey> 
{
    public  bool IsActive { get; set; } = true;
    public  bool IsDeleted { get; set; } = false;

    public string? CreatedBy { get; set; }

    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

    public string? LastModifiedBy { get; set; }

    public DateTime LastModifiedUtc { get; set; }
}
