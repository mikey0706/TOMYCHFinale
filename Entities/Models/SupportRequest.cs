using Common.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SupportRequest
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public string IssueDescription { get; set; }
        public UrgencyTypes UrgencyLevel { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public RequestStatusTypes Status { get; set; }
        public string? StatusDetails { get; set; }
        public IssueTypes IssueType { get; set; }
        public string? IssueSubject { get; set; }
        public ICollection<SupportRequestMessages> Messages { get; set; }
    }
}
