using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbSettings;

public partial class PasswordManagerContext : DbContext
{
    public PasswordManagerContext()
    {
    }

    public PasswordManagerContext(DbContextOptions<PasswordManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> User { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PasswordManager; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.UserMail).IsRequired().HasMaxLength(255).IsUnicode();
            entity.HasIndex(e => e.UserMail).IsUnique();
            entity.Property(e => e.Password).IsRequired().HasMaxLength(255).IsUnicode();
            entity.Property(e => e.CreationDate).HasDefaultValueSql("GETDATE()");
        });
    }
}
