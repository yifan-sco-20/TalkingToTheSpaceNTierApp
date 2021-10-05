using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public Int64 User_ID { get; set; } //(PK)
        public String Username { get; set; }
        public String User_Password { get; set; }
        public String User_Profile_Name { get; set; }
        public String User_Email { get; set; }
        public Int64 User_Point { get; set; }
        public DateTime User_Creation_Date { get; set; }

        //RELATIONSHIPS
        // An user can have many messages.
        // A message though belongs to only 1 user at a time.
        public ICollection<Message> Messages { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
