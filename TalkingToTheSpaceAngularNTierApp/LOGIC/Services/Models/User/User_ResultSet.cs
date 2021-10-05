using System;

namespace LOGIC.Services.Models.User
{
    public class User_ResultSet
    {
        public Int64 user_id { get; set; } //(PK)
        public String username { get; set; }
        public String user_password { get; set; }
        public String user_profile_name { get; set; }
        public String user_email { get; set; }
        public Int64 user_point { get; set; }
        public DateTime user_creation_date { get; set; }

    }
}