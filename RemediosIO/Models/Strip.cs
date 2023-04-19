using System;
using System.Collections.Generic;

namespace RemediosIO.Models;

public partial class Strip
{
    public int Id { get; set; }

    public string StripName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
