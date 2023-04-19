using System;
using System.Collections.Generic;

namespace RemediosIO.Models;

public partial class Medicine
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string? DosageInstructions { get; set; }

    public string? Warnings { get; set; }

    public DateTime? Postedat { get; set; }

    public int? IdSupplier { get; set; }

    public int? IdStrip { get; set; }

    public int? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Strip? IdStripNavigation { get; set; }

    public virtual Supplier? IdSupplierNavigation { get; set; }

    public virtual ICollection<Pharmacy> IdPharmacies { get; set; } = new List<Pharmacy>();

    public virtual ICollection<Supplier> IdSuppliers { get; set; } = new List<Supplier>();
}
