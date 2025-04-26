using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace apiii.Models;

public partial class LehaContext : DbContext
{
    public LehaContext()
    {
    }

    public LehaContext(DbContextOptions<LehaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<News> News { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=147.45.196.64;Port=5432;Database=leha;Username=strhzy;Password=12345678");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("news_pkey");

            entity.ToTable("news");

            entity.Property(e => e.NewsId).HasColumnName("news_id");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .HasColumnName("author");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PublicationDate).HasColumnName("publication_date");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
