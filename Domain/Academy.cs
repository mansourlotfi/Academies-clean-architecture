using System;

namespace Domain;

public class Academy
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string TenantId { get; set; } = Guid.NewGuid().ToString(); // ID to associate the academy with a tenant
    public required string Name { get; set; } // Name of the academy
    public required string Address { get; set; } // Physical address
    public required string ContactInfo { get; set; } // Contact details like phone or email
    public string? LogoUrl { get; set; } // URL for the academy's logo
    // public List<Branch> Branches { get; set; } // Collection of branches associated with the academy
    public DateTime CreatedDate { get; set; } // Timestamp for when the academy was created
    public DateTime UpdatedDate { get; set; } // Timestamp for the last update

}
