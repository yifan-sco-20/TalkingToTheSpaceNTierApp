using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Reply
{
    public class Reply_Pass_Object
    {
        public Int64 reply_id { get; set; } //(PK)
        public String reply_content { get; set; }
        public String reply_status { get; set; }
        public DateTime reply_creation_date { get; set; }
        public DateTime reply_modified_date { get; set; }
        public DateTime reply_sent_date { get; set; }
        public Int64 user_id { get; set; } //(FK)
        public Int64 message_id { get; set; } //(FK)
    }
}
