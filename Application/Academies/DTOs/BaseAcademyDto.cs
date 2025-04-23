using System;

namespace Application.Academies.DTOs;

public class BaseAcademyDto
{
    // [Required] data anotation gives us better validation agains required modifier.
    // we used a package called fluentvalidation
    public string Name { get; set; } = "";  // Name of the academy
    public string Address { get; set; } = ""; // Physical address
    public string ContactInfo { get; set; } = "";// Contact details like phone or email
    public string? LogoUrl { get; set; } // URL for the academy's logo
    // public List<Branch> Branches { get; set; } // Collection of branches associated with the academy
    public DateTime CreatedDate { get; set; } // Timestamp for when the academy was created
    public DateTime UpdatedDate { get; set; } // Timestamp for the last update

    //location props
    public string City { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
