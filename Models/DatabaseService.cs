using SQLite;

namespace ExpenseBuddyJenish.Models
{
    internal class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<int> CreateUserAsync(User user) => _database.InsertAsync(user);

        public Task<User> GetUserAsync(string email, string password) =>
            _database.Table<User>().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        public Task<User> GetUserByEmailAsync(string email) =>
            _database.Table<User>().FirstOrDefaultAsync(u => u.Email == email);
    }
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
    }
}


