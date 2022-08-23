using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public string CreatedBy { get; set; } = "SYSTEM";
}