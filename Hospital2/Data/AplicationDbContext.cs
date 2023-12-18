using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital.Data;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }




}
