using LOGIC.Services.Models;
using LOGIC.Services.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IMessage_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Message_ResultSet>>> GetAllMessages();
        Task<Generic_ResultSet<Message_ResultSet>> GetMessageByMessageId(Int64 message_id);

        //todo: 
        //Task<Generic_ResultSet<Message_ResultSet>> GetMessageByUserId(Int64 user_id);

        //Task<Generic_ResultSet<Message_ResultSet>> GetMessageByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface

        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Message_ResultSet>> AddMessage(string message_content, string message_status,  DateTime message_sent_date, Int64 user_id);
        Task<Generic_ResultSet<Message_ResultSet>> UpdateMessage(Int64 message_id, string message_content, string message_status, DateTime message_modified_date, DateTime message_sent_date);
        Task<Generic_ResultSet<bool>> DeleteMessage(Int64 message_id);


    }
}
