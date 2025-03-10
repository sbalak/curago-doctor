﻿using Microsoft.EntityFrameworkCore;

namespace Doctor.Data
{
    public class DoctorContext : DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext> options) : base(options) 
        {
        }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<SpecialityToSymptom> SpecialityToSymptoms { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffEducation> StaffEducations { get; set; }
        public DbSet<StaffIdentifier> StaffIdentifiers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Staff>().Property(m => m.FirstName).HasMaxLength(50);
            builder.Entity<Staff>().Property(m => m.LastName).HasMaxLength(50);
            builder.Entity<Staff>().Property(m => m.Latitude).HasMaxLength(200);
            builder.Entity<Staff>().Property(m => m.Longitude).HasMaxLength(200);
        }
    }
}