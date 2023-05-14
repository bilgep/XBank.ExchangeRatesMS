using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace XBank.M02.ClientService.Entities
{
    [PrimaryKey("AccountId")]
    public class Account
    {
        [Required]
        public long AccountId { get; set; }
        [Required]
        public string AccountType { get; set; }

        [Required]
        public string Balance { get; set; } = "0";
    }
}
