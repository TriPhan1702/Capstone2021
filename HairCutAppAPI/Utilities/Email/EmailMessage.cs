using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace HairCutAppAPI.Utilities.Email
{
    public class EmailMessage
    {
        public MailboxAddress To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        
        public EmailMessage(string to, string subject, string content)
        {
            To = new MailboxAddress(to);
            Subject = subject;
            Content = content;        
        }
    }
}