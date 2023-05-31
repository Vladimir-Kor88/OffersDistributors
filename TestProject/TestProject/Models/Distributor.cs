using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime CreatedDate { get; set; }
    }
}
