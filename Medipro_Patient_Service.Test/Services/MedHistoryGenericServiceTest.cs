using System.Linq.Expressions;
using AutoMapper;
using JetBrains.Annotations;
using medipro_patient_service.Application.DTO;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Services;
using medipro_patient_service.Domain.Models;
using Moq;

namespace Medipro_Patient_Service.Test.Services;

[TestSubject(typeof(MedHistoryGenericService<Entity, BaseDto>))]
public class MedHistoryGenericServiceTest
{

    private readonly Mock<IGenericRepository<Entity>> _mockRepo;
    private readonly Mock<IUserDetailsHelper> _helper;
    private readonly Mock<IMapper> _mapper;
    private readonly MedHistoryGenericService<Entity, BaseDto> _service;

    public MedHistoryGenericServiceTest()
    {
        _mockRepo = new Mock<IGenericRepository<Entity>>();
        _helper = new Mock<IUserDetailsHelper>();
        _mapper = new Mock<IMapper>();
        _service = new MedHistoryGenericService<Entity, BaseDto>(_mockRepo.Object, _helper.Object, _mapper.Object);

    }
    
    [Fact]
    public async void AddAsyncTest_Success()
    {
        var allergy = new Allergy();
        var dto = new AllergyDto();

        _helper.Setup(h => h.GetMedHistoryId()).ReturnsAsync(new Guid().ToString);
        _mockRepo.Setup(m => m.AddAsync(It.IsAny<Entity>())).ReturnsAsync(allergy);
        _mapper.Setup(m => m.Map<Entity>(It.IsAny<BaseDto>())).Returns(allergy);
        _mapper.Setup(m => m.Map<BaseDto>(It.IsAny<Entity>())).Returns(dto);
        var response = await _service.AddAsync(dto);
        Assert.NotNull(response);
        Assert.Equal("Operation Successful", response.Message);
        Assert.NotNull(response.Data);
    }

    [Fact]
    public async void AddAsyncTest_Fail()
    {
        var dto = new AllergyDto();
        _helper.Setup(h => h.GetMedHistoryId()).ReturnsAsync(string.Empty);
        // var response = await _service.AddAsync(dto);
        var ex = await Assert.ThrowsAsync<Exception>(() =>  _service.AddAsync(dto));
        Assert.Equal("Inavlid request", ex.Message);
    }

    [Fact]
    public async void UpdateAsyncTest_Success()
    {
        var allergy = new Allergy();
        var dto = new AllergyDto();
        _mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(allergy);
        _mapper.Setup(m => m.Map<Entity>(It.IsAny<BaseDto>())).Returns(allergy);
        _mapper.Setup(m => m.Map<BaseDto>(It.IsAny<Entity>())).Returns(dto);
        _mockRepo.Setup(m => m.UpdateAsync(It.IsAny<Entity>())).ReturnsAsync(true);
        var response = await _service.UpdateAsync(dto);
        Assert.NotNull(response);
        _mockRepo.Verify(m => m.UpdateAsync(It.IsAny<Entity>()), Times.Once);
        Assert.Equal(200, response.StatusCode);
    }
    
    [Fact]
    public async void UpdateAsyncTest_Fail()
    {
        var allergy = new Allergy();
        var dto = new AllergyDto();
        _mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((Entity)null!);
        var ex = await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync(dto));
        Assert.Equal("Inavlid request", ex.Message);
    }

    [Fact]
    public async void GetAsyncTest_Success()
    {
        var repo = new Mock<IGenericRepository<Allergy>>();
        var service = new MedHistoryGenericService<Allergy, AllergyDto>(repo.Object, _helper.Object, _mapper.Object);
        IEnumerable<Allergy> allergies = new List<Allergy>
        {
            new Allergy(), new Allergy()
        };
        var dto = new AllergyDto();
        _helper.Setup(h => h.GetMedHistoryId()).ReturnsAsync(new Guid().ToString);
        repo.Setup(m => m.FindAndIncludeAsync(
                It.IsAny<Expression<Func<Allergy, bool>>>(), It.IsAny<string[]>()))
            .ReturnsAsync(allergies);
        _mapper.Setup(m => m.Map<BaseDto>(It.IsAny<Entity>())).Returns(dto);
        var response = await service.GetAsync();
        var dtos = (List<AllergyDto>)response.Data;
        Assert.NotNull(response);
        repo.Verify(m => m.FindAndIncludeAsync(
            It.IsAny<Expression<Func<Allergy, bool>>>(), It.IsAny<string[]>()), Times.Once());
        Assert.Equal(2, dtos.Count);
    }

    [Fact]
    public async void GetAsyncTest_Fail()
    {
        var allergies = new List<Allergy>
        {
            new Allergy(), new Allergy()
        };
        _mockRepo.Setup(m => m.FindAndIncludeAsync(
                It.IsAny<Expression<Func<Entity, bool>>>(), It.IsAny<string[]>()))
            .ReturnsAsync(allergies);
        await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetAsync());
    }
    
    [Fact]
    public async void DeleteAsyncTest_Success()
    {
        var allergy = new Allergy();
        _mockRepo.Setup(m => m.FindAsync(It.IsAny<Expression<Func<Entity, bool>>>()))
            .ReturnsAsync(allergy);
        var response = await _service.DeleteAsync(new Guid().ToString());
        Assert.NotNull(response);
        _mockRepo.Verify(m => m.RemoveAsync(It.IsAny<Entity>()), Times.Once);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async void DeleteAsyncTest_Fail()
    {
        _mockRepo.Setup(m => m.FindAsync(It.IsAny<Expression<Func<Entity, bool>>>()))
            .ReturnsAsync((Entity) null!);
        await Assert.ThrowsAsync<Exception>(() => _service.DeleteAsync(new Guid().ToString()));
    }
}