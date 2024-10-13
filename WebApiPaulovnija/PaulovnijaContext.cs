using Microsoft.EntityFrameworkCore;
using WebApiPaulovnija.Models;

public class PaulovnijaContext : DbContext
{
    public PaulovnijaContext(DbContextOptions<PaulovnijaContext> options) : base(options)
    {
    }

    public DbSet<Radnik> Radnici { get; set; }
    public DbSet<Zadatak> Zadaci { get; set; }
    public DbSet<Sadnica> Sadnice { get; set; }
    public DbSet<Stroj> Strojevi { get; set; }
    public DbSet<Rasadnik> Rasadnik { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Radnik>().HasKey(r => r.ID_Radnika);
        modelBuilder.Entity<Zadatak>().HasKey(z => z.ID_Zadatka);
        modelBuilder.Entity<Sadnica>().HasKey(s => s.ID_Sadnice);
        modelBuilder.Entity<Stroj>().HasKey(st => st.ID_Stroja);
        modelBuilder.Entity<Rasadnik>().HasKey(rs => rs.ID_Rasadnika);

        
        modelBuilder.Entity<Sadnica>()
            .HasOne(s => s.Rasadnik)
            .WithMany(r => r.Sadnice)
            .HasForeignKey(s => s.ID_Rasadnika);

        modelBuilder.Entity<Stroj>()
    .HasOne(st => st.Radnik)
    .WithMany(r => r.Strojevi)
    .HasForeignKey(st => st.ID_Radnika)
    .HasPrincipalKey(r => r.ID_Radnika);

        modelBuilder.Entity<Zadatak>()
  .HasOne(z => z.Radnik)
  .WithMany(r => r.Zadaci)
  .HasForeignKey(z => z.ID_Radnika);
    }
}

