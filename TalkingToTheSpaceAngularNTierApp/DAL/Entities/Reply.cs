using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Reply
    {
        public Int64 Reply_ID { get; set; } //(PK)
        public String Reply_Content { get; set; }
        public String Reply_Status { get; set; }
        public DateTime Reply_Creation_Date { get; set; }
        public DateTime Reply_Modified_Date { get; set; }
        public DateTime Reply_Sent_Date { get; set; }
        public Int64 User_ID { get; set; } //(FK)
        public Int64 Message_ID { get; set; } //(FK)

        //RELATIONSHIPS
        //Each Reply belongs to a specific User: User_ID
        public User User { get; set; }

        //Each Reply links to only 1 Message: Message_ID
        public Message Message { get; set; }
    }
}
