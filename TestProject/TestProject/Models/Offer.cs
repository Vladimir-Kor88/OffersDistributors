using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Mark { get; set; } = "";
        public string Model { get; set; } = "";
        public Distributor? Distributor { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
