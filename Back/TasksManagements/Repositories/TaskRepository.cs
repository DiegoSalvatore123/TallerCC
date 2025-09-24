using Microsoft.EntityFrameworkCore;
using System.Net;
using TasksManagements.Helpers;
using TasksManagements.Interfaces;
using TasksManagements.Model;
using TasksManagements.Repositories.DbContext;

namespace TasksManagements.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContextInMemory _context;

        public TaskRepository(DbContextInMemory context)  
        {
            _context = context;
        }

        public async Task<List<TaskManagement>> GetAll()
        {
            List<TaskManagement>lst= await _context.TasksManagements.ToListAsync();
            return lst;
        }

        public async Task<HttpResponseMessage> GetById(int id)
        {
            TaskManagement? task= await _context.TasksManagements.FindAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, task);
        }

        public async Task<HttpResponseMessage> Create(TaskManagement task)
        {
            task.Id = _context.TasksManagements.Any() ? _context.TasksManagements.Max(p => p.Id) + 1 : 1;
            _context.TasksManagements.Add(task);
            await _context.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK, "OK");
        }

        public async Task<HttpResponseMessage> Update(int id, TaskManagement task) {
            var oldtask = _context.TasksManagements.FirstOrDefault(p => p.Id == id);
            if (oldtask == null)
                return Request.CreateResponse(HttpStatusCode.OK, "Data not found");
            oldtask.Status = task.Status;
            _context.TasksManagements.Update(oldtask);
            await _context.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK, "OK");
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var task = _context.TasksManagements.FirstOrDefault(p => p.Id == id);
            if (task == null)
                return Request.CreateResponse(HttpStatusCode.OK, "Data not found");
            _context.TasksManagements.Remove(task);
            await _context.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK, "OK");
        }
    }
}
