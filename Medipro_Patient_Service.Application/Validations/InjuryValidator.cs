using FluentValidation;
using medipro_patient_service.Application.DTO;

namespace medipro_patient_service.Application.Validations;

public abstract class InjuryValidator : AbstractValidator<InjuryDto>
{
    protected InjuryValidator()
    {
        RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description is required");
        RuleFor(x => x.Outcome).NotEmpty().NotNull().WithMessage("Outcome is required");
    }
}

public abstract class ChronicConditionValidator : AbstractValidator<ChronicConditionDto>
{
    protected ChronicConditionValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Name is required");
        RuleFor(c => c.Status).NotEmpty().NotNull().WithMessage("Status is required");
        RuleFor(c => c.DiagonoseDate).NotEmpty().NotNull().WithMessage("Diagonose date is required");
    }
}

public abstract class SurgeryValidator : AbstractValidator<SurgeryDto>
{
    protected SurgeryValidator()
    {
        RuleFor(x => x.Outcome).IsInEnum().NotNull().WithMessage("Outcome is required");
        RuleFor(x => x.Hospital).NotEmpty().NotNull().WithMessage("Hospital is required");
    }
}

public abstract class IllnessValidator : AbstractValidator<IllnessDto>
{
    protected IllnessValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Name is required");
        RuleFor(c => c.Outcome).IsInEnum().NotNull().WithMessage("Outcome is required");
    }
}