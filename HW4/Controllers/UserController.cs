using System.Text.Json;
using HW4.Contracts;
using HW4.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
    {
        [HttpGet("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            logger.LogInformation("'{MethodName}' with parameter '{UserId}' was called", nameof(GetUserById), userId);

            var user = await userService.GetUser(userId);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel model)
        {
            logger.LogInformation("'{MethodName}' with parameter '{Model}' was called", nameof(CreateUser), JsonSerializer.Serialize(model));

            var newUser = await userService.CreateUser(model);
            return Ok(newUser);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel model)
        {
            logger.LogInformation("'{MethodName}' with parameter '{Model}' was called", nameof(UpdateUser), JsonSerializer.Serialize(model));

            var updatedUser = await userService.UpdateUser(model);
            return updatedUser != null ? Ok(updatedUser) : NotFound();
        }

        [HttpDelete("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            logger.LogInformation("'{MethodName}' with parameter '{UserId}' was called", nameof(DeleteUser), userId);
            
            var result = await userService.DeleteUser(userId);
            return result ? Ok() : NotFound();
        }
    }
}
