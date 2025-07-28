using APIPractice.Data;
using APIPractice.Models.Domain;
using APIPractice.Models.DTO.TaskHistory;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TaskHistoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var tasksHistory = dbContext.TasksHistory.ToList();

            var tasksHistoryDto = new List<GetTaskHistoryDto>();
            foreach (var taskHistory in tasksHistory)
            {
                tasksHistoryDto.Add(new GetTaskHistoryDto()
                {
                    Id = taskHistory.Id,
                    OrderId = taskHistory.OrderId,
                    EmployeeId = taskHistory.EmployeeId,
                    AcceptedAt = taskHistory.AcceptedAt,
                    CompletedAt = taskHistory.CompletedAt
                });
            }

            return Ok(tasksHistoryDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var taskHistory = dbContext.TasksHistory.Find(id);

            var taskHistory = dbContext.TasksHistory.FirstOrDefault(x => x.Id == id);

            if (taskHistory == null)
            {
                return NotFound();
            }

            var taskHistoryDto = new GetTaskHistoryDto
            {
                Id = taskHistory.Id,
                OrderId = taskHistory.OrderId,
                EmployeeId = taskHistory.EmployeeId,
                AcceptedAt = taskHistory.AcceptedAt,
                CompletedAt = taskHistory.CompletedAt
            };

            return Ok(taskHistoryDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskHistoryDto taskHistoryDto)
        {
            var taskHistory = new TaskHistory
            {
                Id = Guid.NewGuid(),
                OrderId = taskHistoryDto.OrderId,
                EmployeeId = taskHistoryDto.EmployeeId,
                AcceptedAt = DateTime.UtcNow
            };

            dbContext.TasksHistory.Add(taskHistory);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id)
        {
            var taskHistory = dbContext.TasksHistory.FirstOrDefault(x => x.Id == id);

            if(taskHistory == null)
            {
                return NotFound();
            }

            taskHistory.CompletedAt = DateTime.UtcNow;

            dbContext.SaveChanges();

            var getTaskHistoryDto = new GetTaskHistoryDto
            {
                Id = taskHistory.Id,
                OrderId = taskHistory.OrderId,
                EmployeeId = taskHistory.EmployeeId,
                AcceptedAt = taskHistory.AcceptedAt,
                CompletedAt = taskHistory.CompletedAt
            };

            return Ok(getTaskHistoryDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var taskHistory = dbContext.TasksHistory.FirstOrDefault(x => x.Id == id);
            if (taskHistory == null)
            {
                return NotFound();
            }

            dbContext.TasksHistory.Remove(taskHistory);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
