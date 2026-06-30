namespace ChatShared.Models
{
    public class FileMessage
    {
        public string Sender { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string Extension { get; set; } = string.Empty;
        public Guid FileId { get; set; } = Guid.NewGuid();
        public int ChunkIndex { get; set; }
        public int TotalChunks { get; set; }
        public byte[] Data { get; set; } = Array.Empty<byte>();
        public bool IsLastChunk { get; set; }
    }
}
