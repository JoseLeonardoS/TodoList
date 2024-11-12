using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;
using TodoListAPI.Models.DTOs;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITaskInterface _taskInterface;

        public TarefasController(ITaskInterface taskInterface)
        {
            _taskInterface = taskInterface;
        }

        [HttpGet("pendentes")]
        public async Task<ActionResult<List<TaskModel>>> ListTasks()
        {
            var tasks = await _taskInterface.ListTasks();
            return Ok(tasks);
        }

        [HttpGet("completas")]
        public async Task<ActionResult<List<TaskModel>>> ListTasksDone()
        {
            var tasks = await _taskInterface.ListTasksDone();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            var task = await _taskInterface.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost("criar")]
        public async Task<ActionResult<TaskModel>> CreateTask(CreateTaskDTO task)
        {
            var tsk = await _taskInterface.CreateTask(task);
            return Ok(tsk);
        }

        [HttpPut("editar")]
        public async Task<ActionResult<TaskModel>> UpdateTask(UpdateTaskDTO task)
        {
            var tsk = await _taskInterface.UpdateTask(task);
            return Ok(tsk);
        }

        [HttpPut("marcar")]
        public async Task<ActionResult<TaskModel>> MarkCheckBox(MarkTaskDTO task)
        {
            var tsk = await _taskInterface.MarkCheckBox(task);
            return Ok(tsk);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            var task = await _taskInterface.DeleteTask(id);
            return Ok(task);
        }
    }
}
