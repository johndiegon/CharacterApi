using Domain.Commands.Batlle;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CharacterApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BattleController : ControllerBase
    {

        private readonly IMediator _mediator;

        public BattleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Action to create a new "character" in the database.
        /// </summary>
        /// <param name="name">Character's name</param>
        /// <param name="profession">Profession's name</param>
        /// <returns>Returns the created character</returns>
        /// <response code="200">Returned if the character was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<PostBatlleCommandResponse>> Post(PostBatlleCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                if (response.Status == StatusRequest.Sucessed)
                {
                    return Ok(response);
                }
                else
                {
                    return UnprocessableEntity(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
