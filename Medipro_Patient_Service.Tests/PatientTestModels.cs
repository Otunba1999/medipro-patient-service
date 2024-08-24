using System.Collections;
using medipro_patient_service.Application.Patient.Dtos;
using medipro_patient_service.Domain.Enums;
using medipro_patient_service.Domain.Models;

namespace Medipro_Patient_Service.Tests;

public static class PatientTestModels
{
    public static BasicInfo GetBasicInfo()
    {
        return new BasicInfo()
        {
            FirstName = "test",
            LastName = "test",
            DateOfBirth = new DateOnly(2000, 3, 23),
            Gender = Gender.Male,
            LifeStyle = "test life style",
            Occupation = "test occupation"
        };
    }

    public static Patient GetTestPatient()
    {
        return new Patient()
        {
            Id = Guid.NewGuid(),
            FirstName = "test",
            LastName = "test",
            DateOfBirth = new DateOnly(2000, 3, 23),
            Gender = Gender.Male,
            LifeStyle = "test life style",
            Occupation = "test occupation"
        };
    }

    public static IEnumerable<Patient> GetTestPatients()
    {
        return new List<Patient>
        {
            new Patient
            {
                Id = Guid.NewGuid(), FirstName = "Otunba", LastName = "Range", LifeStyle = "Festival lifestyle",
                Occupation = "Enginner", DateOfBirth = new DateOnly(2000, 03, 23), Gender = Gender.Male,
                CurrentMedications = new List<Medication>(), MedicalHistory = new MedicalHistory(),
                PastMedicalHistory = new PastMedicalHistory(), Contact = new Contact(), DateCreated = DateTime.Now,
                DateModified = DateTime.Today, UserId = "some string"
            },
            new Patient
            {
                Id = Guid.NewGuid(), FirstName = "Range", LastName = "Otunba", LifeStyle = "Club lifestyle",
                Occupation = "Developer", DateOfBirth = new DateOnly(2000, 12, 12), Gender = Gender.Female,
                CurrentMedications = new List<Medication>(), MedicalHistory = new MedicalHistory(),
                PastMedicalHistory = new PastMedicalHistory(), Contact = new Contact(), DateCreated = DateTime.Now,
                DateModified = DateTime.Today, UserId = "some string"
            },
        };
    }
}