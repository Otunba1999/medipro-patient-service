using System.Linq.Expressions;
using AutoMapper;
using JetBrains.Annotations;
using medipro_patient_service.Application.DTO;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.HttpService;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Services;
using Medipro_Patient_Service.Common.Requests;
using Medipro_Patient_Service.Common.Responses;
using medipro_patient_service.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace Medipro_Patient_Service.Test.Services;

[TestSubject(typeof(PatientService))]
public class PatientServiceTest
{
    private readonly Mock<IGenericRepository<Patient>> _patientRepo;
    private readonly Mock<IGenericRepository<MedicalHistory>> _medRepo;
    private readonly Mock<ILogger<PatientService>> _logger;
    private readonly Mock<IUserDetailsHelper> _helper;
    private readonly Mock<IHttpService<MailRequest>> _httpService;
    private readonly Mock<IMapper> _mapper;
    private readonly PatientService _service;
    private readonly UserDetail _userDetail;
    private string _id;

    public PatientServiceTest()
    {
        _patientRepo = new Mock<IGenericRepository<Patient>>();
        _medRepo = new Mock<IGenericRepository<MedicalHistory>>();
        _logger = new Mock<ILogger<PatientService>>();
        _helper = new Mock<IUserDetailsHelper>();
        _httpService = new Mock<IHttpService<MailRequest>>();
        _mapper = new Mock<IMapper>();
        _service = new PatientService(_patientRepo.Object, _mapper.Object, _helper.Object, _httpService.Object, _logger.Object,
            _medRepo.Object);
        _id = new Guid().ToString();
        _userDetail = new UserDetail(_id, "test@email.com", "Test Name", null);
    }

    [Fact]
    public async void AddAsyncTest_Success()
    {
        var patient = new Patient();
        var dto = new PatientDto();
        var info = new BasicInfo();
        var med = new MedicalHistory();
        ;
        _helper.Setup(h => h.GetUserDetail()).Returns(_userDetail);
        _mapper.Setup(m => m.Map<Patient>(It.IsAny<PatientDto>())).Returns(patient);
        _mapper.Setup(m => m.Map<PatientDto>(It.IsAny<Patient>())).Returns(dto);
        _httpService.Setup(h => 
                h.Add(It.IsAny<MailRequest>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
            .ReturnsAsync(new Response<object>());
        _patientRepo.Setup(p => p.FindAsync(It.IsAny<Expression<Func<Patient, bool>>>()))
            .ReturnsAsync((Patient)null!);
        _patientRepo.Setup(p => p.AddAsync(It.IsAny<Patient>())).ReturnsAsync(patient);
        _medRepo.Setup(m => m.AddAsync(It.IsAny<MedicalHistory>())).ReturnsAsync(med);
        var response = await _service.AddAsync(info);
        Assert.NotNull(response);
        _patientRepo.Verify(p => p.FindAsync(It.IsAny<Expression<Func<Patient, bool>>>()), Times.Once);
        _patientRepo.Verify(p => p.AddAsync(It.IsAny<Patient>()), Times.Once);
        _medRepo.Verify(p => p.AddAsync(It.IsAny<MedicalHistory>()), Times.Once);
    }

    [Fact]
    public async void AddAsyncTest_Fail_If_UserDetail_IsNull()
    {
        var info = new BasicInfo();
        _helper.Setup(h => h.GetUserDetail()).Returns((UserDetail)null!);
        var ex = await Assert.ThrowsAsync<Exception>(() => _service.AddAsync(info));
        Assert.Equal("Inavlid request", ex.Message);
    }

    [Fact]
    public async void AddAsyncTest_Fail_If_Patient_Exist()
    {
        var patient = new Patient();
        var info = new BasicInfo();
        _helper.Setup(h => h.GetUserDetail()).Returns(_userDetail);
        _patientRepo.Setup(p => p.FindAsync(It.IsAny<Expression<Func<Patient, bool>>>()))
            .ReturnsAsync(patient);
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => _service.AddAsync(info));
        Assert.Equal("Record already exist", ex.Message);
    }

    [Fact]
    public async void GetAllAsync_Test()
    {
        var dto = new PatientDto();
        var pats = new List<Patient>()
        {
            new Patient(), new Patient()
        };
        _helper.Setup(h => h.GetUserDetail()).Returns(_userDetail);
        _mapper.Setup(m => m.Map<PatientDto>(It.IsAny<Patient>())).Returns(dto);
        _patientRepo.Setup(p => p.GetAllAsync(It.IsAny<string[]>())).ReturnsAsync(pats);
        var response = await _service.GetAllPatients();
        var dtos = (List<PatientDto>)response.Data!;
        Assert.NotNull(response);
        Assert.Equal(200, response.StatusCode);
        _patientRepo.Verify(p => p.GetAllAsync(It.IsAny<string[]>()), Times.Once);
        Assert.Equal(2, dtos.Count);
    }

    [Fact]
    public async void GetPatient_Test()
    {
        var dto = new PatientDto();
        var pats = new List<Patient>()
        {
            new Patient{UserId = _id}
        };
        _helper.Setup(h => h.GetUserDetail()).Returns(_userDetail);
        _mapper.Setup(m => m.Map<PatientDto>(It.IsAny<Patient>())).Returns(dto);
        _patientRepo.Setup(p => p.FindAndIncludeAsync(
                It.IsAny<Expression<Func<Patient, bool>>>(), It.IsAny<string[]>()))
            .ReturnsAsync(pats);
        var response = await _service.GetPatient();
        Assert.NotNull(response);
    }
}