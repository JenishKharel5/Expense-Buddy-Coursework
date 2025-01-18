using SQLite;

namespace ExpenseBuddyJenish.Models
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public string? Type { get; set; } 
        public string? Tags { get; set; } 
        public string? Remarks { get; set; }
        public DateTime Date { get; set; }

        
        public bool Status { get; set; }
    }
}
