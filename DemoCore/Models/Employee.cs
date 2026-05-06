using System.ComponentModel.DataAnnotations;

namespace DemoCore.Models
{
    public class Employee
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

    }
}
