namespace Payroll.Models
{
    class User : Account
    {
        public User()
        {
            IsAdmin = false;
        }
    }
}
