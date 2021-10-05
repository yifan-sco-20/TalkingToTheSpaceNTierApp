using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Message
{
    public class Message_Pass_Object
    {
        public Int64 message_id { get; set; } //(PK)
        public String message_content { get; set; }
        public String message_status { get; set; }
        public DateTime message_creation_date { get; set; }
        public DateTime message_modified_date { get; set; }
        public DateTime message_sent_date { get; set; }

        public Int64 user_id { get; set; } //(FK)
    }
}
