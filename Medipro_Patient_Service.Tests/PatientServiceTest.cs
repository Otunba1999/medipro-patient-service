using AutoMapper;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Patient.Dtos;
using medipro_patient_service.Application.Services;
using medipro_patient_service.Domain.Models;
using Moq;

namespace Medipro_Patient_Service.Tests;

public class PatientServiceTest
{
    private readonly Mock<IGenericRepository<Patient>> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly PatientService _patientService;

    public PatientServiceTest()
    {
        _mockRepo = new Mock<IGenericRepository<Patient>>();
        _mockMapper = new Mock<IMapper>();
        _patientService = new PatientService(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async void AddAsync_Test()
    {
        //Act
        var basicInfo = PatientTestModels.GetBasicInfo();
        // var mockRepo = new Mock<IGenericRepository<Patient>>();
        _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Patient>())).ReturnsAsync(PatientTestModels.GetTestPatient);
        // var mockMapper = new Mock<IMapper>();
        _mockMapper.Setup(mm => mm.Map<PatientDto>(It.IsAny<Patient>())).Returns(new PatientDto());

        // var patientService = new PatientService(mockRepo.Object, mockMapper.Object);
        var response = await _patientService.AddAsync(basicInfo);
        Assert.NotNull(response);
        Assert.NotNull(response.Data);
        _mockRepo.Verify(x => x.AddAsync(It.IsAny<Patient>()), Times.Once);
        _mockMapper.Verify(x => x.Map<PatientDto>(It.IsAny<Patient>()), Times.Exactly(1));
    }

    [Fact]
    public async void GetPatients_Test()
    {
        _mockRepo.Setup(r => r.GetAllAsync(It.IsAny<string[]>())).ReturnsAsync(PatientTestModels.GetTestPatients());
        var response = await _patientService.GetPatient();
        Assert.NotNull(response);
        Assert.Equal(2, response.Data?.Count);
        _mockRepo.Verify(x => x.GetAllAsync(It.IsAny<string[]>()), Times.Exactly(1));
    }
}