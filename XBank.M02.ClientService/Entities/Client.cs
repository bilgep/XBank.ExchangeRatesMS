using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace XBank.M02.ClientService.Entities
{
    [PrimaryKey("ClientId")]
    public class Client
    {
        [Required]
        public long ClientId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

    }
}
