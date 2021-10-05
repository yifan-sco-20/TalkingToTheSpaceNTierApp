using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class User_Service : IUser_Service
    {
        //Reference to our crud functions
        private IUser_Operations _user_operations = new User_Operations();

        public async Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers()
        {
            Generic_ResultSet<List<User_ResultSet>> result = new Generic_ResultSet<List<User_ResultSet>>();
            try
            {
                //GET ALL User userES
                List<User> Useres = await _user_operations.ReadAll();
                //MAP DB User RESULTS
                result.result_set = new List<User_ResultSet>();
                Useres.ForEach(u =>
                {
                    result.result_set.Add(new User_ResultSet
                    {
                        user_id = u.User_ID,
                        username = u.Username,
                        user_password = u.User_Password,
                        user_profile_name = u.User_Profile_Name,
                        user_email = u.User_Email,
                        user_point = u.User_Point
                    }) ;
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All User useres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: GetAllUsers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required User useres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: GetAllUsers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<User_ResultSet>> GetUserByUserId(long user_id)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //GET by ID User 
                var User = await _user_operations.Read(user_id);

                //MAP DB User RESULTS
                result.result_set = new User_ResultSet
                {
                    user_id = User.User_ID,
                    username = User.Username,
                    user_password = User.User_Password,
                    user_profile_name = User.User_Profile_Name,
                    user_email = User.User_Email,
                    user_point = User.User_Point,
                    user_creation_date = User.User_Creation_Date
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - User  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required User  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<User_ResultSet>> AddUser(string username, string user_password, string user_profile_name, string user_email, Int64 user_point)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF User
                User User = new User
                {
                    Username = username,
                    User_Password= user_password,
                    User_Profile_Name = user_profile_name,
                    User_Email = user_email,
                    User_Point= user_point
                };

                //ADD User TO DB
                User = await _user_operations.Create(User);

                //MANUAL MAPPING OF RETURNED User VALUES TO OUR User_ResultSet
                User_ResultSet userAdded = new User_ResultSet
                {
                    user_id = User.User_ID,
                    username = User.Username,
                    user_password = User.User_Password,
                    user_profile_name = User.User_Profile_Name,
                    user_email = User.User_Email,
                    user_point = User.User_Point,
                    user_creation_date = User.User_Creation_Date
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User user {0} was added successfully", user_email);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: AddUser() method executed successfully.";
                result.result_set = userAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the User user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: AddUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<User_ResultSet>> UpdateUser(Int64 user_id, string username, string user_password, string user_profile_name, string user_email, Int64 user_point)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF User
                User User = new User
                {
                    User_ID = user_id,
                    Username = username,
                    User_Password = user_password,
                    User_Profile_Name = user_profile_name,
                    User_Email = user_email,
                    User_Point = user_point
                    //User_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE User IN DB
                User = await _user_operations.Update(User, user_id);

                //MANUAL MAPPING OF RETURNED User VALUES TO OUR User_ResultSet
                User_ResultSet userUpdated = new User_ResultSet
                {
                    user_id = User.User_ID,
                    username = User.Username,
                    user_password = User.User_Password,
                    user_profile_name = User.User_Profile_Name,
                    user_email = User.User_Email,
                    user_point = User.User_Point,
                    user_creation_date = User.User_Creation_Date
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User user {0} was updated successfully", user_email);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: UpdateUser() method executed successfully.";
                result.result_set = userUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the User user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: UpdateUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteUser(long user_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete User IN DB
                var userDeleted = await _user_operations.Delete(user_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User user {0} was deleted successfully", user_id);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: DeleteUser() method executed successfully.";
                result.result_set = userDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the User user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: DeleteUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
