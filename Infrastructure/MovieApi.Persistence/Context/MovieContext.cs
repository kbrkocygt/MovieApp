using System;
using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistence.Context;

public class MovieContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MovieApiDb;User Id=sa;Password=StrongPass1234;TrustServerCertificate=True;");
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Cast> Casts { get; set; }
}


