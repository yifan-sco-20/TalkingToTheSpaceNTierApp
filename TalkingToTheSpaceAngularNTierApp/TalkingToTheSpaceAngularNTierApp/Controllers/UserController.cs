//using LOGIC.Services.Interfaces;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WEB_API.Models.User;

//namespace WEB_API.Controllers
//{
//    [EnableCors("angular")]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private IUser_Service _User_Service;

//        public UserController(IUser_Service User_Service)
//        {
//            _User_Service = User_Service;
//        }

//        [HttpPost]
//        [Route("[action]")]
//        public async Task<IActionResult> AddUser(string username, string user_password, string user_profile_name, string user_email, Int64 user_point)
//        {
//            var result = await _User_Service.AddUser(username, user_password, user_profile_name, user_email, user_point);
//            switch (result.success)
//            {
//                case true:
//                    return Ok(result);

//                case false:
//                    return StatusCode(500, result);
//            }
//        }

//        [HttpGet]
//        [Route("[action]")]
//        public async Task<IActionResult> GetAllUsers()
//        {
//            var result = await _User_Service.GetAllUsers();
//            switch (result.success)
//            {
//                case true:
//                    return Ok(result);

//                case false:
//                    return StatusCode(500, result);
//            }
//        }

//        [HttpPost]
//        [Route("[action]")]
//        public async Task<IActionResult> UpdateUser(User_Pass_Object user)
//        {
//            var result = await _User_Service.UpdateUser(user.id, user.name);
//            switch (result.success)
//            {
//                case true:
//                    return Ok(result);

//                case false:
//                    return StatusCode(500, result);
//            }
//        }

//        [HttpPost]
//        [Route("[action]")]
//        public async Task<IActionResult> DeleteUser(User_Pass_Object user)
//        {
//            var result = await _User_Service.DeleteUser(user.id);
//            switch (result.success)
//            {
//                case true:
//                    return Ok(result);

//                case false:
//                    return StatusCode(500, result);
//            }
//        }

//    }
//}
