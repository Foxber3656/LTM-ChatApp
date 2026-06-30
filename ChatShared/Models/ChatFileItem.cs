namespace ChatClient.Models
{
    public class ChatFileItem
    {
        public string User { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
