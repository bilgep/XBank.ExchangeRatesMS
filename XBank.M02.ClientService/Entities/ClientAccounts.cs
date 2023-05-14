using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XBank.M02.ClientService.Entities
{
    [PrimaryKey("Id")]
    public class ClientAccounts
    {
        [Required]
        public long Id { get; set; }

        public long ClientId { get; set; }

        public long AccountId { get; set; }
        public string AccountType { get; set; } 
    }
}
