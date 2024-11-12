using TodoListAPI.Models;
using TodoListAPI.Models.DTOs;

namespace TodoListAPI.Services
{
    public interface ITaskInterface
    {
        public Task<ResponseModel<List<TaskModel>>> ListTasks();
        public Task<ResponseModel<List<TaskModel>>> ListTasksDone();
        public Task<ResponseModel<TaskModel>> GetTaskById(int id);
        public Task<ResponseModel<TaskModel>> MarkCheckBox(MarkTaskDTO task);
        public Task<ResponseModel<TaskModel>> CreateTask(CreateTaskDTO task);
        public Task<ResponseModel<TaskModel>> UpdateTask(UpdateTaskDTO task);
        public Task<ResponseModel<TaskModel>> DeleteTask(int id);
    }
}
