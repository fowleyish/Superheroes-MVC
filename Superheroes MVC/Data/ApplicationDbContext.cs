using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Superheroes_MVC.Models;

namespace Superheroes_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<Superhero> Superheroes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
