using App.Core.Contracts;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Infrastructure.DatabaseContext;

public class AppDbContext :DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {}

    public DbSet<Student> Student { get; set; }

    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // If yauy gusto mo i-modify na column like UpdatedAt and UpdatedBy
        // I-follow tong source code ni sir na may another method sa taas para sa pag update ng uban columns.
        // Kay ang inhimo ko ngadi kay may default values ko na daan sa uban properties sa BaseEntity.
        return await base.SaveChangesAsync(cancellationToken);
    }
}