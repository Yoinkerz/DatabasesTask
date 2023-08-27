using System.ComponentModel.DataAnnotations;

namespace Submission_Task_Datalagring.Models.Entities;

public class ErrandEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public string CurrentTime { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Email { get; set; } = null!;
}
