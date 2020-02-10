using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using base_project.Contracts;
using base_project.Entities.Response;
using base_project.Entities.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace base_project.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    [SwaggerTag("Endpoints de Usuarios")]
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        /// <summary>
        /// Ingreso de Usuarios Nuevos.
        /// </summary>
        /// <param name="usersRequest">Parámetros de entrada del servicio, en formato json</param>
        /// <returns>Objeto de respuesta con información de ingreso de usuarios.</returns>
        [SwaggerResponse(200, "Success", typeof(string))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponseEntity))]
        [SwaggerResponse(500, "Internal server Error", typeof(ErrorResponseEntity))]
        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UsersEntity>> Create([FromBody] UsersEntity usersRequest)
        {
            bool result = await _service.CreateUsers(usersRequest);            
            return Ok(result);
        }

    }

    

}