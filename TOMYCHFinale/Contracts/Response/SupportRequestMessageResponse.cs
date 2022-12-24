namespace TOMYCHFinale.Contracts.Response
{
    public class SupportRequestMessageResponse
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
