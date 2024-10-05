using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.StoreDB.DOMAIN.Core.DTO;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;

namespace UESAN.StoreDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody]UserRequestAuthDTO userRequestAuthDTO)
        {
           var result = await _userService.SignUp(userRequestAuthDTO);
            if (!result) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserAuthDTO userAuthDTO)
        {
            if(userAuthDTO.Email == "" || userAuthDTO.Password == "") return BadRequest();
            //TODO: Mejorar el userService con DTO
            var result = await _userService.SignIn(userAuthDTO.Email, userAuthDTO.Password);
            if (result == null) return NotFound();
            return Ok(result);
        }


    }
}
