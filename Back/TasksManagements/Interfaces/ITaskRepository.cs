using TasksManagements.Model;

namespace TasksManagements.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskManagement>> GetAll();
        Task<HttpResponseMessage> GetById(int id);
        Task<HttpResponseMessage> Create(TaskManagement task);
        Task<HttpResponseMessage> Update(int id, TaskManagement task);
        Task<HttpResponseMessage> Delete(int id);
    }
}
