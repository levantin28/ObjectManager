using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OM.Common.CQRS.Commands.Dispatcher;
using OM.Common.CQRS.Queries.Dispatcher;
using OM.Services.ObjectManager.BLL.Commands.GeneralObjects;
using OM.Services.ObjectManager.BLL.Commands.Relations;
using OM.Services.ObjectManager.BLL.Queries.GeneralObjects;
using OM.Services.ObjectManager.BLL.Queries.Relations;
using OM.Services.ObjectManager.Core.Models.API;
using OM.Services.ObjectManager.Core.Models.Entities;

namespace OM.Services.ObjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationsController : ControllerBase
    {
        // Fields to store instances of ICommandDispatcher and IQueryDispatcher.
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        // Constructor to initialize the controller with the necessary dependencies.
        public RelationsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // API endpoint for creating a new relation via a POST request.
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRelationCommand command)
        {
            // Dispatches the create command using the injected command dispatcher.
            var result = await _commandDispatcher.DispatchAsync(command);

            // Checks if the operation was not successful and returns a BadRequest response.
            if (!result.IsValid)
                return BadRequest(result);

            // Returns an Ok response if the operation was successful.
            return Ok();
        }

        // API endpoint for updating an existing relation via a PUT request.
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRelationCommand command)
        {
            // Dispatches the update command using the injected command dispatcher.
            var result = await _commandDispatcher.DispatchAsync(command);

            // Checks if the operation was not successful and returns a BadRequest response.
            if (!result.IsValid)
                return BadRequest(result);

            // Returns an Ok response if the operation was successful.
            return Ok();
        }

        // API endpoint for deleting a relation via a DELETE request.
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteRelationCommand command)
        {
            // Dispatches the delete command using the injected command dispatcher.
            var result = await _commandDispatcher.DispatchAsync(command);

            // Checks if the operation was not successful and returns a BadRequest response.
            if (!result.IsValid)
                return BadRequest(result);

            // Returns an Ok response if the operation was successful.
            return Ok();
        }

        // API endpoint for retrieving a relation by its ID via a GET request.
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(RelationApiModel), StatusCodes.Status200OK)]
        public async Task<Relation> Get(Guid id)
        {
            // Creates a query to retrieve a relation by its ID.
            var query = new GetRelationQuery(id);

            // Dispatches the query using the injected query dispatcher and returns the result.
            return await _queryDispatcher.DispatchAsync(query);
        }

        // API endpoint for retrieving all relations via a GET request.
        [HttpGet("all")]
        [ProducesResponseType(typeof(List<RelationApiModel>), StatusCodes.Status200OK)]
        public async Task<List<Relation>> GetAll()
        {
            // Dispatches a query to retrieve all relations using the injected query dispatcher.
            return await _queryDispatcher.DispatchAsync(new GetRelationsQuery());
        }
    }
}
