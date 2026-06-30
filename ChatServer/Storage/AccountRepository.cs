using ChatShared.Models;

namespace ChatServer.Storage
{
    public class AccountRepository
    {
        private readonly string file = Path.Combine("Data", "users.json");
        private readonly List<Account> accounts;

        public AccountRepository()
        {
            Directory.CreateDirectory("Data"); 
            accounts = JsonStorage.Load<Account>(file);
        }

        public List<Account> GetAll()
        {
            return accounts;
        }

        public Account? Find(string username)
        {
            return accounts.FirstOrDefault(x =>
                x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public bool Exists(string username)
        {
            return Find(username) != null;
        }

        public bool Add(Account account)
        {
            if (Exists(account.UserName))
                return false;

            accounts.Add(account);

            Save();

            return true;
        }

        public bool Delete(string username)
        {
            Account? account = Find(username);

            if (account == null)
                return false;

            accounts.Remove(account);

            Save();

            return true;
        }

        public void Save()
        {
            JsonStorage.Save(file, accounts);
        }
    }
}