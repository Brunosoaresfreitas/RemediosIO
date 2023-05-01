using System;
using System.Collections.Generic;

namespace RemediosIO.Models;

public partial class Category
{
    public Category(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

    public void Update(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}
