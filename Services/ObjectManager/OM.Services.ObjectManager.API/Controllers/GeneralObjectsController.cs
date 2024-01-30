using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OM.Common.CQRS.Commands.Dispatcher;
using OM.Common.CQRS.Queries.Dispatcher;
using OM.Services.ObjectManager.BLL.Commands.GeneralObjects;
using OM.Services.ObjectManager.BLL.Queries.GeneralObjects;
using OM.Services.ObjectManager.Core.Models.API;
using OM.Services.ObjectManager.Core.Models.Entities;

namespace OM.Services.ObjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralObjectsController : ControllerBase
    {
        // Fields to store instances of ICommandDispatcher and IQueryDispatcher.
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        // Constructor to initialize the controllers with the necessary dependencies.
        public GeneralObjectsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // API endpoint for creating a new GeneralObject via a POST request.
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateGeneralObjectCommand command)
        {
            // Dispatches the create command using the injected command dispatcher.
            var result = await _commandDispatcher.DispatchAsync(command);

            // Checks if the operation was not successful and returns a BadRequest response.
            if (!result.IsValid)
                return BadRequest(result);

            // Returns an Ok response if the operation was successful.
            return Ok();
        }

        // API endpoint for updating an existing GeneralObject via a PUT request.
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateGeneralObjectCommand command)
        {
            // Dispatches the update command using the injected command dispatcher.
            var result = await _commandDispatcher.DispatchAsync(command);

            // Checks if the operation was not successful and returns a BadRequest response.
            if (!result.IsValid)
                return BadRequest(result);

            // Returns an Ok response if the operation was successful.
            return Ok();
        }

        // API endpoint for deleting a GeneralObject via a DELETE request.
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteGeneralObjectCommand command)
        {
            // Dispatches the delete command using the injected command dispatcher.
            var result = await _commandDispatcher.DispatchAsync(command);

            // Checks if the operation was not successful and returns a BadRequest response.
            if (!result.IsValid)
                return BadRequest(result);

            // Returns an Ok response if the operation was successful.
            return Ok();
        }

        // API endpoint for retrieving a GeneralObject by its ID via a GET request.
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GeneralObjectApiModel), StatusCodes.Status200OK)]
        public async Task<GeneralObject> Get(int id)
        {
            // Creates a query to retrieve a GeneralObject by ID.
            var query = new GetGeneralObjectQuery(id);

            // Dispatches the query using the injected query dispatcher and returns the result.
            return await _queryDispatcher.DispatchAsync(query);
        }

        // API endpoint for retrieving GeneralObjects by their type via a GET request.
        [HttpGet("{type}")]
        [ProducesResponseType(typeof(GeneralObjectApiModel), StatusCodes.Status200OK)]
        public async Task<List<GeneralObject>> GetByType(string type)
        {
            // Creates a query to retrieve GeneralObjects by type.
            var query = new GetGeneralObjectByTypeQuery(type);

            // Dispatches the query using the injected query dispatcher and returns the result.
            return await _queryDispatcher.DispatchAsync(query);
        }

        // API endpoint for searching GeneralObjects by a search string via a GET request.
        [HttpGet("search/{searchString}")]
        [ProducesResponseType(typeof(GeneralObjectApiModel), StatusCodes.Status200OK)]
        public async Task<List<GeneralObject>> Get(string searchString)
        {
            // Creates a query to search for GeneralObjects by a specified search string.
            var query = new SearchGeneralObjectsQuery(searchString);

            // Dispatches the query using the injected query dispatcher and returns the result.
            return await _queryDispatcher.DispatchAsync(query);
        }

        // API endpoint for retrieving all GeneralObjects via a GET request.
        [HttpGet("all")]
        [ProducesResponseType(typeof(List<GeneralObjectApiModel>), StatusCodes.Status200OK)]
        public async Task<List<GeneralObject>> GetAll()
        {
            // Dispatches a query to retrieve all GeneralObjects using the injected query dispatcher.
            return await _queryDispatcher.DispatchAsync(new GetGeneralObjectsQuery());
        }

        // API endpoint for retrieving child GeneralObjects by the ID of a parent via a GET request.
        [HttpGet("childs/{id:int}")]
        [ProducesResponseType(typeof(List<GeneralObjectApiModel>), StatusCodes.Status200OK)]
        public async Task<List<GeneralObject>> GetChilds(int id)
        {
            // Dispatches a query to retrieve child GeneralObjects by the ID of a parent.
            return await _queryDispatcher.DispatchAsync(new GetChildsGeneralObjectsQuery(id));
        }

        // API endpoint for retrieving parent GeneralObjects by the ID of a child via a GET request.
        [HttpGet("parents/{id:int}")]
        [ProducesResponseType(typeof(List<GeneralObjectApiModel>), StatusCodes.Status200OK)]
        public async Task<List<GeneralObject>> GetParents(int id)
        {
            // Dispatches a query to retrieve parent GeneralObjects by the ID of a child.
            return await _queryDispatcher.DispatchAsync(new GetParentsGeneralObjectsQuery(id));
        }
        
    }
}
