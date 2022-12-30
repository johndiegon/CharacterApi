using Domain.Commands.Character.Delete;
using Domain.Commands.Character.Post;
using Domain.Enums;
using Domain.Models;
using Domain.Models.Command;
using Domain.Queries.Character.GetDetails;
using Domain.Queries.Character.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CharacterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CharacterController(IMediator mediator)
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
        public async Task<ActionResult<CommandResponse<CharacterModel>>> Create(string name, Profession profession)
        {
            try
            {
                var character = new PostCharacterCommand() { Character = new CharacterModel(name, profession) };

                var response = await _mediator.Send(character);
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

       
        /// <summary>
        ///     Action to update a character in the database.
        /// </summary>
        /// <param name="name">Character's name</param>
        /// <returns>Returns the deleted character</returns>
        /// <response code="200">Returned if the character was deleted</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpDelete]
        public async Task<ActionResult<CommandResponse<object>>> Update(string name)
        {
            try
            {
                var putCommand = new DeleteCharacterCommand() { Name = name};

                var response = await _mediator.Send(putCommand);
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


        /// <summary>
        ///     Action to get a character detail by name.
        /// </summary>
        /// <param name="name">Characters name</param>
        /// <returns>Returns the character.</returns>
        /// <response code="200">Returned if the character was returned</response>
        /// <response code="204">Returned if the character couldn't be parsed</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("details")]
        public async Task<ActionResult<CommandResponse<object>>> GetDetails([FromQuery] string name)
        {
            try
            {
                var query = new GetCharacterDetailsQuery() { Name = name };

                var response = await _mediator.Send(query);
                if (response.Status == StatusRequest.Sucessed)
                {
                    if (response.Data != null)
                        return Ok(response);
                    else
                        return NoContent();
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

        /// <summary>
        ///     Action to get a list of characters in the database.
        /// </summary>
        /// <param name="page">Page to return</param>
        /// <param name="count">Count of character for page</param>
        /// <returns>Returns the characters </returns>
        /// <response code="200">Returned if the character was returned</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<ActionResult<GetCharacterListResponse>> Get([FromQuery] int? page, [FromQuery] int? count )
        {
            try
            {
                var query = new GetCharacterListQuery(){Page = page == null ? 1 : page.Value, Count = count == null ? 100 : count.Value };

                var response = await _mediator.Send(query);
                if (response.Status == StatusRequest.Sucessed)
                {
                    if (response.Data.Any())
                        return Ok(response);
                    else
                        return NoContent();
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
   
