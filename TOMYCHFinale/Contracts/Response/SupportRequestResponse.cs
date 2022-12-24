using Common.Enums;
using Services.BusinessObjects;

namespace TOMYCHFinale.Contracts.Response
{
    public class SupportRequestResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public UserResponse User { get; set; }
        public string IssueDescription { get; set; }
        public UrgencyTypes UrgencyLevel { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public RequestStatusTypes Status { get; set; }
        public string StatusDetails { get; set; }
        public IssueTypes IssueType { get; set; }
        public string IssueSubject { get; set; }
        public ICollection<SupportRequestMessageResponse> Messages { get; set; }
    }
}
