using Common.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessObjects
{
    public class SupportRequestBO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public UserBO User { get; set; }
        public string IssueDescription { get; set; }
        public UrgencyTypes UrgencyLevel { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public RequestStatusTypes Status { get; set; }
        public string StatusDetails { get; set; }
        public IssueTypes IssueType { get; set; }
        public string IssueSubject { get; set; }
        public ICollection<SupportRequestMessagesBO> Messages { get; set; }
    }
}
