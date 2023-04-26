using System;
using System.Collections.Generic;

namespace RemediosIO.Models;

public partial class Client
{
    public Client(string name, string cpf, string address, string? medicalHistory, string phonenumber, int? idPharmacy)
    {
        Name = name;
        Cpf = cpf;
        Address = address;
        MedicalHistory = medicalHistory;
        Phonenumber = phonenumber;
        IdPharmacy = idPharmacy;
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? MedicalHistory { get; set; }

    public string Phonenumber { get; set; } = null!;

    public int? IdPharmacy { get; set; }

    public virtual Pharmacy? IdPharmacyNavigation { get; set; }
}
