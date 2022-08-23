using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Contracts;

public interface IAppDbContext : IDbContext
{
    public DbSet<Student> Student { get; set; }
}