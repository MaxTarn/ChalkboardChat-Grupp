namespace ChalkBoardChat.Data.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}
