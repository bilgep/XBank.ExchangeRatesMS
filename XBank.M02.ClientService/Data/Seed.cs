using XBank.M02.ClientService.Entities;

namespace XBank.M02.ClientService.Data
{
    public class Seed
    {
        public static List<Client> SeedClients => new List<Client>()
        {
            new Client(){ ClientId = 1, FirstName = "Client01Name", LastName = "Client01LastName" },
            new Client(){ ClientId = 2, FirstName = "Client02Name", LastName = "Client02LastName" },
        };

        public static List<Account> SeedAccounts => new List<Account>()
        {
            new Account(){ AccountId = 1, AccountType = AccountTypes.Euro, Balance = "102.03"},
            new Account(){ AccountId = 2, AccountType = AccountTypes.Usd, Balance = "200.00"},
            new Account(){ AccountId = 3, AccountType = AccountTypes.Euro, Balance = "527.09"},
            new Account(){ AccountId = 4, AccountType = AccountTypes.Usd, Balance = "10000.00"}
        };


        public static List<ClientAccounts> SeedClientAccounts => new List<ClientAccounts>()
        {
            new ClientAccounts() {
                Id = 10,
                ClientId = 1,
                AccountId = 1,
                AccountType = AccountTypes.Euro,
            },

             new ClientAccounts() {
                Id = 11,
                ClientId = 1,
                AccountId =2 ,
                AccountType = AccountTypes.Usd
             },

             new ClientAccounts() {
                Id = 12,
                ClientId = 2,
                AccountId = 3,
                AccountType = AccountTypes.Euro,
             },

             new ClientAccounts() {
                Id = 13,
                ClientId = 2,
                AccountId = 4,
                AccountType = AccountTypes.Usd,
             }
        };
    }
}
