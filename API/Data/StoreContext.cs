using System;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Basket> Baskets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole {Id="36e8486f-6248-490a-9e07-74103d38425a", Name = "User", NormalizedName = "USER" },
                new IdentityRole {Id="ba76a040-de94-4bcf-8a35-b4d675ef527e", Name = "Admin", NormalizedName = "ADMIN" }
            );
    }
}
