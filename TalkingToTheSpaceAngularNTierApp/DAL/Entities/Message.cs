using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Message
    {
        public Int64 Message_ID { get; set; } //(PK)
        public String Message_Content { get; set; }
        public String Message_Status { get; set; }
        public DateTime Message_Creation_Date { get; set; }
        public DateTime Message_Modified_Date { get; set; }
        public DateTime Message_Sent_Date { get; set; }

        public Int64 User_ID { get; set; } //(FK)

        //RELATIONSHIPS
        //Each Message belongs to a specific User: User_ID
        public User User { get; set; }

        // A message can have many replies.
        // A reply though belongs to only 1 message at a time.
        public ICollection<Reply> Replies { get; set; }
    }
}
