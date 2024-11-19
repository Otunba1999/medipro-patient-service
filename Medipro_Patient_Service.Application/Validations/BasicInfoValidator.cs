using FluentValidation;
using medipro_patient_service.Application.DTO;

namespace medipro_patient_service.Application.Validations;

public abstract class BasicInfoValidator: AbstractValidator<BasicInfo>
{
    protected BasicInfoValidator()
    {
        RuleFor(x => x.Gender).IsInEnum().WithMessage("Gender is required");
        RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("Firstname is required");
        RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Lastname is required");
        RuleFor(x => x.Occupation).NotEmpty().NotNull().WithMessage("Occupation is required");
        RuleFor(x => x.DateOfBirth).NotEmpty().NotNull().WithMessage("Date of birth is required");
        
    }
}