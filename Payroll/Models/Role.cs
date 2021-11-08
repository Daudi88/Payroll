using System.ComponentModel.DataAnnotations;

namespace Payroll.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
