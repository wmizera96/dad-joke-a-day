﻿using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;


public class DataContext : IdentityDbContext<AppUser>
{
    public DbSet<Joke>? Jokes { get; set; }   

    public DataContext(DbContextOptions options) : base(options)
    {
    }
}
