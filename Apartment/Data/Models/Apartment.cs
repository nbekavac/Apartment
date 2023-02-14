using System;
using System.Collections.Generic;

namespace Apartment.Data.Models;

public partial class Apartment
{
    public long Id { get; set; }

    public string Name { get; set; }

    public int Bedrooms { get; set; }

    public int Bathrooms { get; set; }

    public string OwnerName { get; set; } 
}
