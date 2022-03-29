namespace MentorMate.Restaurant.Domain.Models.Tables
{
    public class GeneralTableModel
    {
        public int Id { get; set; }
        public  string Status { get; set; }
        public  int Capacity { get; set; }
        public string Waiter { get; set; }
        public string Bill { get; set; }
    }
}
