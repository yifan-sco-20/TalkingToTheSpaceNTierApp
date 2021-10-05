using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Reply;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Reply_Service : IReply_Service
    {
        //Reference to our crud functions
        private IReply_Operations _reply_operations = new Reply_Operations();

        public async Task<Generic_ResultSet<List<Reply_ResultSet>>> GetAllReplys()
        {
            Generic_ResultSet<List<Reply_ResultSet>> result = new Generic_ResultSet<List<Reply_ResultSet>>();
            try
            {
                //GET ALL Reply replyES
                List<Reply> Replyes = await _reply_operations.ReadAll();
                //MAP DB Reply RESULTS
                result.result_set = new List<Reply_ResultSet>();
                Replyes.ForEach(r =>
                {
                    result.result_set.Add(new Reply_ResultSet
                    {
                        reply_id = r.Reply_ID,
                        reply_content = r.Reply_Content,
                        reply_status = r.Reply_Status,
                        reply_creation_date = r.Reply_Creation_Date,
                        reply_modified_date = r.Reply_Modified_Date,
                        reply_sent_date = r.Reply_Sent_Date,
                        user_id = r.User_ID
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Reply replyes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Reply_Service: GetAllReplys() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Reply replyes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reply_Service: GetAllReplys(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Reply_ResultSet>> GetReplyByReplyId(long reply_id)
        {
            Generic_ResultSet<Reply_ResultSet> result = new Generic_ResultSet<Reply_ResultSet>();
            try
            {
                //GET by ID Reply 
                var Reply = await _reply_operations.Read(reply_id);

                //MAP DB Reply RESULTS
                result.result_set = new Reply_ResultSet
                {
                    reply_id = Reply.Reply_ID,
                    reply_content = Reply.Reply_Content,
                    reply_status = Reply.Reply_Status,
                    reply_creation_date = Reply.Reply_Creation_Date,
                    reply_modified_date = Reply.Reply_Modified_Date,
                    reply_sent_date = Reply.Reply_Sent_Date,
                    user_id = Reply.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Reply  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Reply_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Reply  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reply_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Reply_ResultSet>> AddReply(string reply_content, string reply_status, DateTime reply_sent_date, Int64 user_id)
        {
            Generic_ResultSet<Reply_ResultSet> result = new Generic_ResultSet<Reply_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Reply
                Reply Reply = new Reply
                {
                    Reply_Content = reply_content,
                    Reply_Status = reply_status,
                    Reply_Creation_Date = DateTime.UtcNow,
                    Reply_Modified_Date = DateTime.UtcNow,
                    Reply_Sent_Date = reply_sent_date,
                    User_ID = user_id
                };

                //ADD Reply TO DB
                Reply = await _reply_operations.Create(Reply);

                //MANUAL MAPPING OF RETURNED Reply VALUES TO OUR Reply_ResultSet
                Reply_ResultSet replyAdded = new Reply_ResultSet
                {
                    reply_id = Reply.Reply_ID,
                    reply_content = Reply.Reply_Content,
                    reply_status = Reply.Reply_Status,
                    reply_creation_date = Reply.Reply_Creation_Date,
                    reply_modified_date = Reply.Reply_Modified_Date,
                    reply_sent_date = Reply.Reply_Sent_Date,
                    user_id = Reply.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Reply reply {0} was added successfully", reply_content);
                result.internalMessage = "LOGIC.Services.Implementation.Reply_Service: AddReply() method executed successfully.";
                result.result_set = replyAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Reply reply supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reply_Service: AddReply(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Reply_ResultSet>> UpdateReply(Int64 reply_id, string reply_content, string reply_status, DateTime reply_modified_date, DateTime reply_sent_date)
        {
            Generic_ResultSet<Reply_ResultSet> result = new Generic_ResultSet<Reply_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Reply
                Reply Reply = new Reply
                {
                    Reply_ID = reply_id,
                    Reply_Content = reply_content,
                    Reply_Status = reply_status,
                    Reply_Modified_Date = DateTime.UtcNow,
                    Reply_Sent_Date = reply_sent_date
                    //Reply_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Reply IN DB
                Reply = await _reply_operations.Update(Reply, reply_id);

                //MANUAL MAPPING OF RETURNED Reply VALUES TO OUR Reply_ResultSet
                Reply_ResultSet replyUpdated = new Reply_ResultSet
                {
                    reply_id = Reply.Reply_ID,
                    reply_content = Reply.Reply_Content,
                    reply_status = Reply.Reply_Status,
                    reply_creation_date = Reply.Reply_Creation_Date,
                    reply_modified_date = Reply.Reply_Modified_Date,
                    reply_sent_date = Reply.Reply_Sent_Date,
                    user_id = Reply.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Reply reply {0} was updated successfully", reply_content);
                result.internalMessage = "LOGIC.Services.Implementation.Reply_Service: UpdateReply() method executed successfully.";
                result.result_set = replyUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Reply reply supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reply_Service: UpdateReply(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteReply(long reply_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Reply IN DB
                var replyDeleted = await _reply_operations.Delete(reply_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Reply reply {0} was deleted successfully", reply_id);
                result.internalMessage = "LOGIC.Services.Implementation.Reply_Service: DeleteReply() method executed successfully.";
                result.result_set = replyDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Reply reply supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reply_Service: DeleteReply(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
