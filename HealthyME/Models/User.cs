using System.Numerics;

namespace HealthyME.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int PinCode { get; set; }
        public string? MobileNo { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
