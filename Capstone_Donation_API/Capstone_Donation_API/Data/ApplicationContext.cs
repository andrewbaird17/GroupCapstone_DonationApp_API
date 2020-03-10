using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_Donation_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone_Donation_API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donor>().HasData(
                new Donor { Id = 1, AddressId = 1, MedicalId = 1, FirstName = "jerry", LastName = "griswold", IsActive = true},
                new Donor { Id = 2, AddressId = 1, MedicalId = 2, FirstName = "mary", LastName = "griswold", IsActive = true },
                new Donor { Id = 3, AddressId = 2, MedicalId = 3, FirstName = "lisa", LastName = "anderhal", IsActive = true },
                new Donor { Id = 4, AddressId = 3, MedicalId = 4, FirstName = "lucas", LastName = "allen", IsActive = true },
                new Donor { Id = 5, AddressId = 4, MedicalId = 5, FirstName = "marissa", LastName = "gabel", IsActive = true },
                new Donor { Id = 6, AddressId = null, MedicalId = 6, FirstName = "jessica", LastName = "sievers", IsActive = true },
                new Donor { Id = 7, AddressId = 5, MedicalId = 7, FirstName = "trevor", LastName = "smith", IsActive = true },
                new Donor { Id = 8, AddressId = 6, MedicalId = 8, FirstName = "lucy", LastName = "olson", IsActive = true },
                new Donor { Id = 9, AddressId = null, MedicalId = null, FirstName = "gabe", LastName = "neuman", IsActive = true },
                new Donor { Id = 10, AddressId = 7, MedicalId = null, FirstName = "phil", LastName = "jefferson", IsActive = true }
                ) ;
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, StreetAddress = "329 e pleasant st", City = "oconomowoc", State = "wi", ZipCode = 53066 },
                new Address { Id = 2, StreetAddress = "324 s second st", City = "milwaukee", State = "wi", ZipCode = 53204 },
                new Address { Id = 3, StreetAddress = "2100 n kilian pl", City = "milwaukee", State = "wi", ZipCode = 53212 },
                new Address { Id = 4, StreetAddress = "1427 s 75th st", City = "west allis", State = "wi", ZipCode = 53214 },
                new Address { Id = 5, StreetAddress = "874 havenshire rd", City = "naperville", State = "il", ZipCode = 60565 },
                new Address { Id = 6, StreetAddress = "177 mcknight rd n", City = "st paul", State = "mn", ZipCode = 55119 },
                new Address { Id = 7, StreetAddress = "1105 57th st", City = "kenosha", State = "wi", ZipCode = 53140 }
                );
            modelBuilder.Entity<MedicalHistory>().HasData(
                new MedicalHistory { Id = 1, Age = 56, Height = 66, Weight = 205, BloodType = "a+", IsMale = true, Ethnicity = "white", HasAllergies = false, OnMedications = false },
                new MedicalHistory { Id = 2, Age = 53, Height = 50, Weight = 140, BloodType = "b-", IsMale = false, Ethnicity = "white", HasAllergies = false, OnMedications = true },
                new MedicalHistory { Id = 3, Age = 24, Height = 59, Weight = 180, BloodType = "b+", IsMale = false, Ethnicity = "african american", HasAllergies = true, OnMedications = false },
                new MedicalHistory { Id = 4, Age = 33, Height = 48, Weight = 345, BloodType = "o+", IsMale = true, Ethnicity = "white", HasAllergies = true, OnMedications = true },
                new MedicalHistory { Id = 5, Age = 75, Height = 53, Weight = 118, BloodType = "o-", IsMale = false, Ethnicity = " native american/alaskan native", HasAllergies = false, OnMedications = false },
                new MedicalHistory { Id = 6, Age = 64, Height = 63, Weight = 137, BloodType = "ab+", IsMale = false, Ethnicity = "pacific islander", HasAllergies = true, OnMedications = false },
                new MedicalHistory { Id = 7, Age = 19, Height = 56, Weight = 185, BloodType = "ab-", IsMale = true, Ethnicity = "native hawaiian", HasAllergies = false, OnMedications = true },
                new MedicalHistory { Id = 8, Age = 44, Height = 49, Weight = 285, BloodType = "a-", IsMale = false, Ethnicity = "asian", HasAllergies = true, OnMedications = true }
                );
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
    }
}
