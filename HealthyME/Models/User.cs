using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HealthyME.Models
{
    public class User
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        public int PinCode { get; set; }
        public long MobileNo { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public byte[] ProfilePicture { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
