using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.DAL;
using TestApi.Domain;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskEntityController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<MyDbContext>> PostTaskEntity(TaskEntity task)
        {
            using MyDbContext dbContext = new MyDbContext();

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(PostTaskEntity), new { id = task.Id }, task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntity>> GetTaskById(long id)
        {
            using MyDbContext dbContext = new MyDbContext();

            var task = await dbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpDelete("{id}")]
        public async void DeleteTaskById(long id)
        {
            using MyDbContext dbContext = new MyDbContext();
            var taskToDelete = await dbContext.Tasks.FindAsync(id);
            if (taskToDelete != null)
            {
                dbContext.Tasks.Remove(taskToDelete);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
