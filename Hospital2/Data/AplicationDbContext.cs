using Hospital2.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital2.Data;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Poliklinik> Polikliniks { get; set; }

    public DbSet<Doktor> Doktors { get; set; }

    public DbSet<AnaBilimDali> AnaBilimDalis   { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

}
