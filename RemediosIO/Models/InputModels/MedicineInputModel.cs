namespace RemediosIO.Models.InputModels
{
    public class MedicineInputModel
    {
        public string Name { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string? DosageInstructions { get; set; }

        public string? Warnings { get; set; }

        public DateTime? Postedat { get; set; }

        public int? IdSupplier { get; set; }

        public int? IdStrip { get; set; }

        public int? IdCategory { get; set; }
    }
}
