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

[TestSubject(typeof(ContactService))]
public class ContactServiceTest
{
    private readonly Mock<IGenericRepository<Contact>> _mockRepo;
    private readonly Mock<IUserDetailsHelper> _helper;
    private readonly Mock<IMapper> _mapper;
    private readonly ContactService _service;

    public ContactServiceTest()
    {
        _mockRepo = new Mock<IGenericRepository<Contact>>();
        _helper = new Mock<IUserDetailsHelper>();
        _mapper = new Mock<IMapper>();
        _service = new ContactService(_mockRepo.Object, _helper.Object, _mapper.Object);

    }

    [Fact]
    public async void AddAsyncTest_Success()
    {
        var contact = new Contact();
        var dto = new ContactDto();
        _helper.Setup(h => h.GetPatientId()).ReturnsAsync(new Guid().ToString);
        _mockRepo.Setup(m => m.AddAsync(It.IsAny<Contact>())).ReturnsAsync(contact);
        _mapper.Setup(m => m.Map<Contact>(It.IsAny<ContactDto>())).Returns(contact);
        _mapper.Setup(m => m.Map<ContactDto>(It.IsAny<Contact>())).Returns(dto);
        var response = await _service.AddAsync(dto);
        Assert.NotNull(response);
        Assert.Equal("Operation Successful", response.Message);
        Assert.NotNull(response.Data);
    }
    
    [Fact]
    public async void AddAsyncTest_Fail()
    {
        var dto = new ContactDto();
        _helper.Setup(h => h.GetPatientId()).ReturnsAsync(string.Empty);
        var ex = await Assert.ThrowsAsync<Exception>(() =>  _service.AddAsync(dto));
        Assert.Equal("Inavlid request", ex.Message);
    }

    [Fact]
    public async void UpdateAsyncTest_Success()
    {
        var contact = new Contact();
        var dto = new ContactDto();
        _mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(contact);
        _mapper.Setup(m => m.Map<Contact>(It.IsAny<ContactDto>())).Returns(contact);
        _mapper.Setup(m => m.Map<ContactDto>(It.IsAny<Contact>())).Returns(dto);
        _mockRepo.Setup(m => m.UpdateAsync(It.IsAny<Contact>())).ReturnsAsync(true);
        var response = await _service.UpdateAsync(dto);
        Assert.NotNull(response);
        _mockRepo.Verify(m => m.UpdateAsync(It.IsAny<Contact>()), Times.Once);
        Assert.Equal(200, response.StatusCode);
    }
    
    [Fact]
    public async void UpdateAsyncTest_Fail()
    {
        var dto = new ContactDto();
        _mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((Contact)null!);
        var ex = await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync(dto));
        Assert.Equal("Contact does not exist", ex.Message);
    }

    [Fact]
    public async void GetAsyncTest_Success()
    {
        var contacts = new Contact();
        var dto = new ContactDto();
        _helper.Setup(h => h.GetPatientId()).ReturnsAsync(new Guid().ToString);
        _mockRepo.Setup(m => m.FindAsync(
                It.IsAny<Expression<Func<Contact, bool>>>()))
            .ReturnsAsync(contacts);
        _mapper.Setup(m => m.Map<ContactDto>(It.IsAny<Contact>())).Returns(dto);
        var response = await _service.GetAsync();
        Assert.NotNull(response);
        _mockRepo.Verify(m => m.FindAsync(
            It.IsAny<Expression<Func<Contact, bool>>>()), Times.Once());
    }

    
    [Fact]
    public async void DeleteAsyncTest_Success()
    {
        var contact = new Contact();
        _mockRepo.Setup(m => m.FindAsync(It.IsAny<Expression<Func<Contact, bool>>>()))
            .ReturnsAsync(contact);
        var response = await _service.DeleteAsync(new Guid().ToString());
        Assert.NotNull(response);
        _mockRepo.Verify(m => m.RemoveAsync(It.IsAny<Contact>()), Times.Once);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async void DeleteAsyncTest_Fail()
    {
        _mockRepo.Setup(m => m.FindAsync(It.IsAny<Expression<Func<Contact, bool>>>()))
            .ReturnsAsync((Contact) null!);
        await Assert.ThrowsAsync<Exception>(() => _service.DeleteAsync(new Guid().ToString()));
    }
}