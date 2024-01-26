using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Application.Dtos;
using UsersApi.Application.Interfaces;

namespace UsersApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService? _userAppService;

        public UsersController(IUserAppService? userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// Serviço para criação de usuário.
        /// </summary>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(UserCreateResponseDto), 201)]
        public IActionResult Create([FromBody] UserCreateRequestDto request)
        {
            return StatusCode(201, _userAppService?.Create(request));
        }

        /// <summary>
        /// Serviço para autenticação de usuário.
        /// </summary>
        [HttpPost]
        [Route("auth")]
        [ProducesResponseType(typeof(UserAuthResponseDto), 200)]
        public IActionResult Auth([FromBody] UserAuthRequestDto request)
        {
            return StatusCode(200, _userAppService?.Authenticate(request));
        }
    }
}
