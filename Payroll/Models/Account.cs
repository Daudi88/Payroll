using System.ComponentModel.DataAnnotations;

namespace Payroll.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public Role Role { get; set; }
        public bool IsAdmin { get; set; }
    }
}
