using System.ComponentModel.DataAnnotations;
using TestApi.Domain.Enum;

namespace TestApi.Domain;

public class TaskEntity
{
    [Key] public long Id { get; set; }
    
    public long UserId { get; set; }

    public string? Name { get; set; }

    public string? Body { get; set; }

    public TaskType Type { get; set; }
    
    private DateTime CreationTime { get; set; }

    public DateTime Timer { get; set; }
    
    public User? Owner { get; set; }
    
    public TaskEntity()
    {
        Owner = null;
        CreationTime = DateTime.Now;
    }
}