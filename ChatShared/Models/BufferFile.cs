using System.Text.Json.Serialization;

namespace ChatShared.Models
{
    public class BufferFile
    {
        public Guid FileId { get; set; } = Guid.NewGuid();
        public string Sender { get; set; } = string.Empty;

        public string Receiver { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public int ChunkIndex { get; set; }
        public int TotalChunks { get; set; }
        public byte[] Buffer { get; set; } = Array.Empty<byte>();
        [JsonIgnore]
        public MemoryStream Stream { get; } = new();
    }
}
