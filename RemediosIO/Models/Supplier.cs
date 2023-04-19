using System;
using System.Collections.Generic;

namespace RemediosIO.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string SupplierName { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string State { get; set; } = null!;

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

    public virtual ICollection<Medicine> IdMedicines { get; set; } = new List<Medicine>();
}
