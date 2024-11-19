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

[TestSubject(typeof(PastMedHistoryGenericService<Entity, BaseDto>))]
public class PastMedHistoryGenericServiceTest
{
    private readonly Mock<IGenericRepository<Entity>> _mockRepo;
    private readonly Mock<IUserDetailsHelper> _helper;
    private readonly Mock<IMapper> _mapper;
    private readonly PastMedHistoryGenericService<Entity, BaseDto> _service;

    public PastMedHistoryGenericServiceTest()
    {
        _mockRepo = new Mock<IGenericRepository<Entity>>();
        _helper = new Mock<IUserDetailsHelper>();
        _mapper = new Mock<IMapper>();
        _service = new PastMedHistoryGenericService<Entity, BaseDto>(_mockRepo.Object,  _helper.Object, _mapper.Object);

    }

    [Fact]
    public async void AddAsyncTest_Success()
    {
        var illness = new Illness();
        var dto = new IllnessDto();
        _helper.Setup(h => h.GetPastMedHistoryId()).ReturnsAsync(new Guid().ToString);
        _mockRepo.Setup(m => m.AddAsync(It.IsAny<Entity>())).ReturnsAsync(illness);
        _mapper.Setup(m => m.Map<Entity>(It.IsAny<BaseDto>())).Returns(illness);
        _mapper.Setup(m => m.Map<BaseDto>(It.IsAny<Entity>())).Returns(dto);
        var response = await _service.AddAsync(dto);
        Assert.NotNull(response);
        Assert.Equal("Operation Successful", response.Message);
        Assert.NotNull(response.Data);
    }
    
    [Fact]
    public async void AddAsyncTest_Fail()
    {
        var dto = new IllnessDto();
        _helper.Setup(h => h.GetPastMedHistoryId()).ReturnsAsync(string.Empty);
        // var response = await _service.AddAsync(dto);
        var ex = await Assert.ThrowsAsync<Exception>(() =>  _service.AddAsync(dto));
        Assert.Equal("Inavlid request", ex.Message);
    }

    [Fact]
    public async void UpdateAsyncTest_Success()
    {
        var illness = new Illness();
        var dto = new IllnessDto();
        _mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(illness);
        _mapper.Setup(m => m.Map<Entity>(It.IsAny<BaseDto>())).Returns(illness);
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
        var illness = new Illness();
        var dto = new IllnessDto();
        _mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((Entity)null!);
        var ex = await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync(dto));
        Assert.Equal("Inavlid request", ex.Message);
    }

    [Fact]
    public async void GetAsyncTest_Success()
    {
        var repo = new Mock<IGenericRepository<Illness>>();
        var service = new PastMedHistoryGenericService<Illness, IllnessDto>(repo.Object, _helper.Object, _mapper.Object);
        IEnumerable<Illness> illnesses = new List<Illness>
        {
            new Illness(), new Illness()
        };
        var dto = new IllnessDto();
        _helper.Setup(h => h.GetPastMedHistoryId()).ReturnsAsync(new Guid().ToString);
        repo.Setup(m => m.FindAndIncludeAsync(
                It.IsAny<Expression<Func<Illness, bool>>>(), It.IsAny<string[]>()))
            .ReturnsAsync(illnesses);
        _mapper.Setup(m => m.Map<BaseDto>(It.IsAny<Entity>())).Returns(dto);
        var response = await service.GetAsync();
        var dtos = (List<IllnessDto>)response.Data;
        Assert.NotNull(response);
        repo.Verify(m => m.FindAndIncludeAsync(
            It.IsAny<Expression<Func<Illness, bool>>>(), It.IsAny<string[]>()), Times.Once());
        Assert.Equal(2, dtos.Count);
    }

    [Fact]
    public async void GetAsyncTest_Fail()
    {
        var illnesses = new List<Illness>
        {
            new Illness(), new Illness()
        };
        _mockRepo.Setup(m => m.FindAndIncludeAsync(
                It.IsAny<Expression<Func<Entity, bool>>>(), It.IsAny<string[]>()))
            .ReturnsAsync(illnesses);
        await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetAsync());
    }
    
    [Fact]
    public async void DeleteAsyncTest_Success()
    {
        var Illness = new Illness();
        _mockRepo.Setup(m => m.FindAsync(It.IsAny<Expression<Func<Entity, bool>>>()))
            .ReturnsAsync(Illness);
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