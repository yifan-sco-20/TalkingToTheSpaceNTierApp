using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Message;

namespace LOGIC.Services.Implementation
{
    public class Message_Service : IMessage_Service
    {
        //Reference to our crud functions
        private IMessage_Operations _message_operations = new Message_Operations();

        public async Task<Generic_ResultSet<List<Message_ResultSet>>> GetAllMessages()
        {
            Generic_ResultSet<List<Message_ResultSet>> result = new Generic_ResultSet<List<Message_ResultSet>>();
            try
            {
                //GET ALL Message messageES
                List<Message> Messagees = await _message_operations.ReadAll();
                //MAP DB Message RESULTS
                result.result_set = new List<Message_ResultSet>();
                Messagees.ForEach(m =>
                {
                    result.result_set.Add(new Message_ResultSet
                    {
                        message_id = m.Message_ID,
                        message_content = m.Message_Content,
                        message_status = m.Message_Status,
                        message_creation_date = m.Message_Creation_Date,
                        message_modified_date = m.Message_Modified_Date,
                        message_sent_date = m.Message_Sent_Date,
                        user_id = m.User_ID
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage= string.Format("All Message messagees obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: GetAllMessages() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Message messagees from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: GetAllMessages(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Message_ResultSet>> GetMessageByMessageId(long message_id)
        {
            Generic_ResultSet<Message_ResultSet> result = new Generic_ResultSet<Message_ResultSet>();
            try
            {
                //GET by ID Message 
                var Message = await _message_operations.Read(message_id);

                //MAP DB Message RESULTS
                result.result_set = new Message_ResultSet
                {
                    message_id = Message.Message_ID,
                    message_content = Message.Message_Content,
                    message_status = Message.Message_Status,
                    message_creation_date = Message.Message_Creation_Date,
                    message_modified_date = Message.Message_Modified_Date,
                    message_sent_date = Message.Message_Sent_Date,
                    user_id = Message.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Message  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Message  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        


        public async Task<Generic_ResultSet<Message_ResultSet>> AddMessage(string message_content, string message_status, DateTime message_sent_date, Int64 user_id)
        {
            Generic_ResultSet<Message_ResultSet> result = new Generic_ResultSet<Message_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Message
                Message Message = new Message
                {
                    Message_Content = message_content,
                    Message_Status = message_status,
                    Message_Creation_Date = DateTime.UtcNow,
                    Message_Modified_Date = DateTime.UtcNow,
                    Message_Sent_Date = message_sent_date,
                    User_ID = user_id
                };

                //ADD Message TO DB
                Message = await _message_operations.Create(Message);

                //MANUAL MAPPING OF RETURNED Message VALUES TO OUR Message_ResultSet
                Message_ResultSet messageAdded = new Message_ResultSet
                {
                    message_id = Message.Message_ID,
                    message_content = Message.Message_Content,
                    message_status = Message.Message_Status,
                    message_creation_date = Message.Message_Creation_Date,
                    message_modified_date = Message.Message_Modified_Date,
                    message_sent_date = Message.Message_Sent_Date,
                    user_id = Message.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Message message {0} was added successfully", message_content);
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: AddMessage() method executed successfully.";
                result.result_set = messageAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Message message supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: AddMessage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Message_ResultSet>> UpdateMessage(Int64 message_id, string message_content, string message_status, DateTime message_modified_date, DateTime message_sent_date)
        {
            Generic_ResultSet<Message_ResultSet> result = new Generic_ResultSet<Message_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Message
                Message Message = new Message
                {
                    Message_ID = message_id,
                    Message_Content = message_content,
                    Message_Status = message_status,
                    Message_Modified_Date = DateTime.UtcNow,
                    Message_Sent_Date = message_sent_date
                    //Message_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Message IN DB
                Message = await _message_operations.Update(Message, message_id);

                //MANUAL MAPPING OF RETURNED Message VALUES TO OUR Message_ResultSet
                Message_ResultSet messageUpdated = new Message_ResultSet
                {
                    message_id = Message.Message_ID,
                    message_content = Message.Message_Content,
                    message_status = Message.Message_Status,
                    message_creation_date = Message.Message_Creation_Date,
                    message_modified_date = Message.Message_Modified_Date,
                    message_sent_date = Message.Message_Sent_Date,
                    user_id = Message.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Message message {0} was updated successfully", message_content);
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: UpdateMessage() method executed successfully.";
                result.result_set = messageUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Message message supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: UpdateMessage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteMessage(long message_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Message IN DB
                var messageDeleted = await _message_operations.Delete(message_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Message message {0} was deleted successfully", message_id);
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: DeleteMessage() method executed successfully.";
                result.result_set = messageDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Message message supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: DeleteMessage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


    }
}


