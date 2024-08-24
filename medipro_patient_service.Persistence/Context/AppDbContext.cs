using medipro_patient_service.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace medipro_patient_service.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public static AppDbContext Create() => new AppDbContext();
    
    public DbSet<Allergy> Allergies { get; set; }
    public DbSet<ChronicCondition> ChronicConditions { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<FamilyCondition> FamilyConditions { get; set; }
    public DbSet<HealthCareProvider> HealthCareProviders { get; set; }
    public DbSet<Illness> Illnesses { get; set; }
    public DbSet<Immunization> Immunizations { get; set; }
    public DbSet<Injury> Injuries { get; set; }
    public DbSet<MedicalHistory> MedicalHistories { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<PastMedicalHistory> PastMedicalHistories { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PresentIllness> PresentIllnesses { get; set; }
    public DbSet<ReviewOfSystem> ReviewOfSystems { get; set; }
    public DbSet<Screening> Screenings { get; set; }
    public DbSet<SexualHistory> SexualHistories { get; set; }
    public DbSet<SubstanceUse> SubstanceUses { get; set; }
    public DbSet<Surgery> Surgeries { get; set; }
    public DbSet<Vaccination> Vaccinations { get; set; }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (EntityEntry<Entity> entity in ChangeTracker.Entries<Entity>())
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.Entity.DateCreated = DateTime.Now.ToUniversalTime();
                    break;
                case EntityState.Modified:
                    entity.Entity.DateModified = DateTime.Now.ToUniversalTime();
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveAllChanges(CancellationToken cancellationToken) =>
        await SaveChangesAsync(cancellationToken) > 0;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Patient>()
            .Property(p => p.Gender).HasConversion<string>();
        // Patient one to many Relationship with Health care provider
        // modelBuilder.Entity<Patient>()
        //     .HasOne(p => p.HealthCareProvider)
        //     .WithMany(h => h.Patients)
        //     .HasForeignKey(p => p.HealthCareProviderId);
        // Patient one to many Relationship with Medication
        modelBuilder.Entity<Patient>()
            .HasMany(p => p.CurrentMedications)
            .WithOne(c => c.Patient)
            .HasForeignKey(m => m.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
        // Patient one to one relationship with Contact
        modelBuilder.Entity<Patient>()
            .HasOne(p => p.Contact)
            .WithOne(c => c.Patient)
            .HasForeignKey<Contact>(c => c.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
        // Patient one to one relationship with Medical history
        modelBuilder.Entity<Patient>()
            .HasOne(p => p.MedicalHistory)
            .WithOne(m => m.Patient)
            .HasForeignKey<MedicalHistory>(m => m.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
        // Patient one to one relationship with Past Medical History
        modelBuilder.Entity<Patient>()
            .HasOne(p => p.PastMedicalHistory)
            .WithOne(p => p.Patient)
            .HasForeignKey<PastMedicalHistory>(p => p.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
        // Medical History one to many relationship with Medication
        modelBuilder.Entity<MedicalHistory>()
            .HasMany(m => m.CurentMedications)
            .WithOne(m => m.MedicalHistory)
            .HasForeignKey(m => m.MedicalHistoryId);
        // modelBuilder.Entity<MedicalHistory>()
        //     .HasMany(m => m.PastMedications)
        //     .WithOne(m => m.MedicalHistory)
        //     .HasForeignKey(m => m.MedicalHistoryId);
        // Medical History one to many relationship with Allergy
        modelBuilder.Entity<MedicalHistory>()
            .HasMany(m => m.Allergies)
            .WithOne(a => a.MedicalHistory)
            .HasForeignKey(a => a.MedicalHistoryId);
        // Medical History one to many relationship with Medication
        modelBuilder.Entity<MedicalHistory>()
            .HasMany(m => m.FamilyConditions)
            .WithOne(f => f.MedicalHistory)
            .HasForeignKey(f => f.MedicalHistoryId);
        // Medical History one to many relationship with Imminization
        modelBuilder.Entity<MedicalHistory>()
            .HasMany(m => m.Immunizations)
            .WithOne(i => i.MedicalHistory)
            .HasForeignKey(i => i.MedicalHistoryId);
        // Medical History one to many relationship with Medication
        modelBuilder.Entity<MedicalHistory>()
            .HasMany(m => m.Screenings)
            .WithOne(s => s.MedicalHistory)
            .HasForeignKey(s => s.MedicalHistoryId);
        // Medical History one to many relationship with Medication
        modelBuilder.Entity<MedicalHistory>()
            .HasMany(m => m.Vaccinations)
            .WithOne(v => v.MedicalHistory)
            .HasForeignKey(v => v.MedicalHistoryId);
        // Medical History one to one relationship with Substance use
        modelBuilder.Entity<MedicalHistory>()
            .HasOne(m => m.SubstanceUse)
            .WithOne(s => s.MedicalHistory)
            .HasForeignKey<SubstanceUse>(s => s.MedicalHistoryId);
        // Medical History one to one relationship with Sexual History
        modelBuilder.Entity<MedicalHistory>()
            .HasOne(m => m.SexualHistory)
            .WithOne(s => s.MedicalHistory)
            .HasForeignKey<SexualHistory>(s => s.MedicalHistoryId);
        // Medical History one to one relationship with Review Of System
        modelBuilder.Entity<MedicalHistory>()
            .HasOne(m => m.ReviewOfSystem)
            .WithOne(r => r.MedicalHistory)
            .HasForeignKey<ReviewOfSystem>(r => r.MedicalHistoryId);
        // Medical History one to one relationship with Present Illness
        modelBuilder.Entity<MedicalHistory>()
            .HasOne(m => m.SubstanceUse)
            .WithOne(s => s.MedicalHistory)
            .HasForeignKey<SubstanceUse>(s => s.MedicalHistoryId);
        // Medical History one to one relationship with Present Illness
        modelBuilder.Entity<MedicalHistory>()
            .HasOne(m => m.PresentIllness)
            .WithOne(p => p.MedicalHistory)
            .HasForeignKey<PresentIllness>(p => p.MedicalHistoryId);
        // Past Medical History one to many relationship witj Chronic Condition
        modelBuilder.Entity<PastMedicalHistory>()
            .HasMany(p => p.ChronicConditions)
            .WithOne(c => c.PastMedicalHistory)
            .HasForeignKey(c => c.PastMedicalHistoryId)
            .OnDelete(DeleteBehavior.Cascade);
        // Past Medical History one to many relationship witj Surgery
        modelBuilder.Entity<PastMedicalHistory>()
            .HasMany(p => p.Surgeries)
            .WithOne(s => s.PastMedicalHistory)
            .HasForeignKey(s => s.PastMedicalHistoryId)
            .OnDelete(DeleteBehavior.Cascade);
        // Past Medical History one to many relationship witj Illness
        modelBuilder.Entity<PastMedicalHistory>()
            .HasMany(p => p.Illnesses)
            .WithOne(i => i.PastMedicalHistory)
            .HasForeignKey(i => i.PastMedicalHistoryId)
            .OnDelete(DeleteBehavior.Cascade);
        // Past Medical History one to many relationship witj Injury
        modelBuilder.Entity<PastMedicalHistory>()
            .HasMany(p => p.Injuries)
            .WithOne(i => i.PastMedicalHistory)
            .HasForeignKey(i => i.PastMedicalHistoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}