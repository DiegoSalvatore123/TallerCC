using Microsoft.AspNetCore.Mvc;
using TasksManagements.Interfaces;
using TasksManagements.Model;

namespace TasksManagements.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _task;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _task = taskRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Getting all Tasks");
                var data = await _task.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] TaskManagement task)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Insert new Task");
                HttpResponseMessage data = await _task.Create(task);
                var response = await this.StandardizeResponse(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, TaskManagement task)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Updating the Task with Id {id}");
                HttpResponseMessage data = await  _task.Update(id, task);
                var response = await this.StandardizeResponse(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Deleting the Task by Id {id}");
                HttpResponseMessage data = await _task.Delete(id);
                var response = await this.StandardizeResponse(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(StatusCode(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}

