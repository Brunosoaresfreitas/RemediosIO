namespace RemediosIO.Models.InputModels
{
    public class ClientInputModel
    {
        public string Name { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string? MedicalHistory { get; set; }

        public string Phonenumber { get; set; } = null!;

        public int? IdPharmacy { get; set; }
    }
}
