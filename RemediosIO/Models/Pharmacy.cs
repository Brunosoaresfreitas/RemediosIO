using System;
using System.Collections.Generic;

namespace RemediosIO.Models;

public partial class Pharmacy
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Medicine> IdMedicines { get; set; } = new List<Medicine>();
}
