using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace medipro_patient_service.Api.Controllers;

public class ContactController(IGenericService<Contact> service) : GenericController<ContactDto, Contact>(service)
{
}