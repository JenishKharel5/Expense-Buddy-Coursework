namespace ExpenseBuddyJenish.Models
{
    public class AddTransactionViewModel
    {
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Credit", "Debit", "Debt"
        public string Tags { get; set; }
        public string Remarks { get; set; }

        public Transaction ToTransaction()
        {
            return new Transaction
            {
                Amount = Amount,
                Type = Type,
                Tags = Tags,
                Remarks = Remarks,
                Date = DateTime.Now
            };
        }
    }
}
