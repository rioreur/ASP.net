using System.Diagnostics.CodeAnalysis;
using Isen.Dotnet.Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Isen.Dotnet.Library.Context
{    
    public class ApplicationDbContext : DbContext
    {        
        // Listes des classes modèle / tables
        public DbSet<Person> PersonCollection { get; set; }
        public DbSet<City> CityCollection { get; set; }
        public DbSet<Service> ServiceCollection { get; set; }
        public DbSet<Role> RoleCollection { get; set; }

        public ApplicationDbContext(
            [NotNullAttribute] DbContextOptions options) : 
            base(options) {  }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tables et relations
            modelBuilder
                // Associer la classe Person...
                .Entity<Person>()
                // ... à la table Person
                .ToTable(nameof(Person))
                // Description de la relation Person.BirthCity
                .HasOne(p => p.BirthCity)
                // Relation réciproque (omise)
                .WithMany()
                // Clé étrangère qui porte cette relation
                .HasForeignKey(p => p.BirthCityId);
            // Pareil pour ResidenceCity
            modelBuilder.Entity<Person>()
                .HasOne(p => p.ResidenceCity)
                .WithMany()
                .HasForeignKey(p => p.ResidenceCityId);
            // Pareil pour Service
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Service)
                .WithMany()
                .HasForeignKey(p => p.ServiceId);
            // Et utiliser le champ Id comme clé primaire
            // Déclaration optionnelle, car le nommage
            // Id ou PersonId est reconnu comme convention
            // pour les clés primaires ou étrangères
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);

            // Pareil pour City
            modelBuilder.Entity<City>()
                .ToTable(nameof(City))
                .HasKey(c => c.Id);
            // Pareil pour Service
            modelBuilder.Entity<Service>()
                .ToTable(nameof(Service))
                .HasKey(s => s.Id);
            // Pareil pour Role
            modelBuilder.Entity<Role>()
                .ToTable(nameof(Role))
                .HasKey(p => p.Id);

            // Création de la relation many with many entre Role et Person
            modelBuilder.Entity<RolePerson>()
                .HasKey(bc => new { bc.RoleId, bc.PersonId });  
            modelBuilder.Entity<RolePerson>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePersons)
                .HasForeignKey(rp => rp.RoleId);  
            modelBuilder.Entity<RolePerson>()
                .HasOne(rp => rp.Person)
                .WithMany(p => p.RolePersons)
                .HasForeignKey(rp => rp.PersonId);
        }

    }
}