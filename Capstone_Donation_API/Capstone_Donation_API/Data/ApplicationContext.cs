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
                new Donor { DonorId = 1, AddressId = 1, FirstName = "jerry", LastName = "griswold", IsActive = true},
                new Donor { DonorId = 2, AddressId = 1, FirstName = "mary", LastName = "griswold", IsActive = true },
                new Donor { DonorId = 3, AddressId = 2, FirstName = "lisa", LastName = "anderhal", IsActive = true },
                new Donor { DonorId = 4, AddressId = 3, FirstName = "lucas", LastName = "allen", IsActive = true },
                new Donor { DonorId = 5, AddressId = 4, FirstName = "marissa", LastName = "gabel", IsActive = true },
                new Donor { DonorId = 6, AddressId = 5, FirstName = "jessica", LastName = "sievers", IsActive = true },
                new Donor { DonorId = 7, AddressId = 6, FirstName = "trevor", LastName = "smith", IsActive = true },
                new Donor { DonorId = 8, AddressId = 7, FirstName = "lucy", LastName = "olson", IsActive = true },
                new Donor { DonorId = 9, AddressId = 8, FirstName = "gabe", LastName = "neuman", IsActive = true },
                new Donor { DonorId = 10, AddressId = 9, FirstName = "phil", LastName = "jefferson", IsActive = true }
                ) ;
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressID = 1, StreetName = "329 e pleasant st", City = "oconomowoc", State = "wi", ZipCode = 53066 },
                new Address { AddressID = 2, StreetName = "324 s second st", City = "milwaukee", State = "wi", ZipCode = 53204 },
                new Address { AddressID = 3, StreetName = "2100 n kilian pl", City = "milwaukee", State = "wi", ZipCode = 53212 },
                new Address { AddressID = 4, StreetName = "1427 s 75th st", City = "west allis", State = "wi", ZipCode = 53214 },
                new Address { AddressID = 5, StreetName = "1100 bowen ct", City = "madison", State = "wi", ZipCode = 53715 },
                new Address { AddressID = 6, StreetName = "874 havenshire rd", City = "naperville", State = "il", ZipCode = 60565 },
                new Address { AddressID = 7, StreetName = "177 mcknight rd n", City = "st paul", State = "mn", ZipCode = 55119 },
                new Address { AddressID = 8, StreetName = "114 douglass ave", City = "waukesha", State = "wi", ZipCode = 53186 },
                new Address { AddressID = 9, StreetName = "1105 57th st", City = "kenosha", State = "wi", ZipCode = 53140 }
                );
            modelBuilder.Entity<MedicalHistory>().HasData(
                new MedicalHistory { MedicalId = 1, DonorId = 1, Age = 56, Height = 66, Weight = 205, BloodType = "a+", IsMale = true, Ethnicity = "white", HasAllergies = false, OnMedications = false },
                new MedicalHistory { MedicalId = 2, DonorId = 2, Age = 53, Height = 50, Weight = 140, BloodType = "b-", IsMale = false, Ethnicity = "white", HasAllergies = false, OnMedications = true },
                new MedicalHistory { MedicalId = 3, DonorId = 3, Age = 24, Height = 59, Weight = 180, BloodType = "b+", IsMale = false, Ethnicity = "african american", HasAllergies = true, OnMedications = false },
                new MedicalHistory { MedicalId = 4, DonorId = 4, Age = 33, Height = 48, Weight = 345, BloodType = "o+", IsMale = true, Ethnicity = "white", HasAllergies = true, OnMedications = true },
                new MedicalHistory { MedicalId = 5, DonorId = 5, Age = 75, Height = 53, Weight = 118, BloodType = "o-", IsMale = false, Ethnicity = " native american/alaskan native", HasAllergies = false, OnMedications = false },
                new MedicalHistory { MedicalId = 6, DonorId = 6, Age = 64, Height = 63, Weight = 137, BloodType = "ab+", IsMale = false, Ethnicity = "pacific islander", HasAllergies = true, OnMedications = false },
                new MedicalHistory { MedicalId = 7, DonorId = 7, Age = 19, Height = 56, Weight = 185, BloodType = "ab-", IsMale = true, Ethnicity = "white", HasAllergies = false, OnMedications = true },
                new MedicalHistory { MedicalId = 8, DonorId = 8, Age = 44, Height = 49, Weight = 285, BloodType = "a-", IsMale = false, Ethnicity = "asian", HasAllergies = true, OnMedications = true },
                new MedicalHistory { MedicalId = 9, DonorId = 9, Age = 22, Height = 65, Weight = 155, BloodType = "ab-", IsMale = true, Ethnicity = "native hawaiian", HasAllergies = false, OnMedications = false },
                new MedicalHistory { MedicalId = 10, DonorId = 10, Age = 30, Height = 55, Weight = 170, BloodType = "ab+", IsMale = true, Ethnicity = "white", HasAllergies = false, OnMedications = true }
                );
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
    }
}
