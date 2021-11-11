namespace Payroll.Models
{
    public abstract class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public string Role { get; set; }
        public bool IsAdmin { get; set; }
    }
}
