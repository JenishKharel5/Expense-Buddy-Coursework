using SQLite;
namespace ExpenseBuddyJenish.Models
{
    public class TransactionService : TransactionServiceBase
    {
        private readonly SQLiteAsyncConnection _database;

        public TransactionService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Transaction>().Wait();
        }

        public Task<int> AddTransactionAsync(Transaction transaction) => _database.InsertAsync(transaction);

        public Task<List<Transaction>> GetTransactionsAsync() => _database.Table<Transaction>().ToListAsync();

        
        public Task<int> DeleteTransactionAsync(int transactionId)
        {
            return _database.DeleteAsync(new Transaction { Id = transactionId });
        }
    }
}
