using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Models;
using TodoListAPI.Models.DTOs;

namespace TodoListAPI.Services
{
    public class TaskService : ITaskInterface
    {
        private readonly TodoContext _context;

        public TaskService(TodoContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<TaskModel>> CreateTask(CreateTaskDTO task)
        {
            ResponseModel<TaskModel> response = new ResponseModel<TaskModel>();

            try
            {
                var tsk = new TaskModel
                {
                    Title = task.Title,
                    Description = task.Description,
                };

                _context.Add(tsk);
                await _context.SaveChangesAsync();

                response.Data = tsk;
                response.Message = "Tarefa criada com sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> DeleteTask(int id)
        {
            ResponseModel<TaskModel> response = new ResponseModel<TaskModel>();

            try
            {
                var tsk = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

                if(tsk == null)
                {
                    response.Data = tsk;
                    response.Message = "Tarefa não encontrada";
                    return response;
                }

                _context.Remove(tsk);
                await _context.SaveChangesAsync();

                response.Data = tsk;
                response.Message = "Tarefa deletada com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> GetTaskById(int id)
        {
            ResponseModel<TaskModel> response = new ResponseModel<TaskModel>();

            try
            {
                var tsk = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

                if(tsk == null)
                {
                    response.Message = "Tarefa não encontrada";
                    return response;
                }

                response.Data = tsk;
                response.Message = "Tarefa encontrada";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> ListTasks()
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>();

            try
            {
                var tasks = await _context.Tasks.Where(x => x.Complete == false).ToListAsync();

                if(tasks.Count > 0)
                {
                    response.Data = tasks;
                    response.Message = "Tarefas listadas com sucesso";

                    return response;
                }

                response.Data = tasks;
                response.Message = "Nenhuma tarefa pendente encontrada";

                return response;
            }
            catch(Exception ex)
            {
                response.Message=ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> ListTasksDone()
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>();

            try
            {
                var tasks = await _context.Tasks.Where(x => x.Complete == true).ToListAsync();

                if (tasks.Count > 0)
                {
                    response.Data = tasks;
                    response.Message = "Tarefas listadas com sucesso";

                    return response;
                }

                response.Data = tasks;
                response.Message = "Nenhuma tarefa pendente encontrada";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> MarkCheckBox(MarkTaskDTO task)
        {
            ResponseModel<TaskModel> response = new ResponseModel<TaskModel>();

            try
            {
                var tsk = await _context.Tasks.FirstAsync(x => x.Id == task.Id);

                if(tsk == null)
                {
                    response.Message = "Tarefa não encontrada";
                    response.Data = tsk;
                    return response;
                }

                tsk.Complete = task.Complete;

                _context.Update(tsk);
                await _context.SaveChangesAsync();

                response.Data = tsk;
                response.Message = "Status atualizado";
                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> UpdateTask(UpdateTaskDTO task)
        {
            ResponseModel<TaskModel> response = new ResponseModel<TaskModel>();

            try
            {
                var tsk = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);

                if (tsk == null)
                {
                    response.Message = "Tarefa não encontrada";
                    response.Data = tsk;
                    return response;
                }

                tsk.Title = task.Title;
                tsk.Description = task.Description;
                
                _context.Update(tsk);
                await _context.SaveChangesAsync();

                response.Data = tsk;
                response.Message = "Tarefa atualizada";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
