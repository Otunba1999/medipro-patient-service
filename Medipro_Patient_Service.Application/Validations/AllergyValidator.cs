using FluentValidation;
using medipro_patient_service.Application.DTO;

namespace medipro_patient_service.Application.Validations;

public abstract class AllergyValidator: AbstractValidator<AllergyDto>
{
    protected AllergyValidator()
    {
        RuleFor(x => x.Allergen).NotEmpty().NotEmpty().WithMessage("Allergen is required");
        RuleFor(x => x.Reaction).NotEmpty().NotEmpty().WithMessage("Reaction is required");
        
    }
}

public abstract class FamilyConditionValidator : AbstractValidator<FamilyConditionDto>
{
    protected FamilyConditionValidator()
    {
        RuleFor(x => x.Condition).NotEmpty().NotNull().WithMessage("Condition is required");
        RuleFor(x => x.Relative).NotEmpty().NotNull().WithMessage("Relative is required");
    }
}
public abstract class ImmunizationValidator : AbstractValidator<ImmunizationDto>
{
    protected ImmunizationValidator()
    {
        RuleFor(x => x.DateAdministered).NotEmpty().NotNull().WithMessage("Date administered is required");
        RuleFor(x => x.VaccineName).NotEmpty().NotNull().WithMessage("Vaccine name is required");
    }
}
public abstract class MedicationValidator : AbstractValidator<MedicationDto>
{
    protected MedicationValidator()
    {
        RuleFor(x => x.Dosage).NotEmpty().NotNull().WithMessage("Dosage is required");
        RuleFor(x => x.StartDate).NotEmpty().NotNull().WithMessage("Start date is required");
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name date is required");
        RuleFor(x => x.EndDate).NotEmpty().NotNull().WithMessage("End date is required");
        RuleFor(x => x.Frequency).IsInEnum().NotNull().WithMessage("Frequency date is required");;
    }
}
public abstract class PresentIllnessValidator : AbstractValidator<PresentIllnessDto>
{
    protected PresentIllnessValidator()
    {
        RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description is required");
        RuleFor(x => x.OnsetDate).NotEmpty().NotNull().WithMessage("On set date is required");
        RuleFor(x => x.AlleviatingFactor).NotEmpty().NotNull().WithMessage("Alleviating factor is required");
        RuleFor(x => x.ExacerbationFactors).NotEmpty().NotNull().WithMessage("Exacerbation factors factor is required");
        RuleFor(x => x.Intensity).IsInEnum().NotNull().WithMessage("Associated symptoms factors factor is required");
    }
}
public abstract class ScreeningValidator : AbstractValidator<ScreeningDto>
{
    protected ScreeningValidator()
    {
        RuleFor(x => x.Type).NotEmpty().NotNull().WithMessage("Type is required");
        RuleFor(x => x.Date).NotEmpty().NotNull().WithMessage("Date is required");
        RuleFor(x => x.Result).NotEmpty().NotNull().WithMessage("Result is required");
    }
}

public abstract class SexualHistoryValidator : AbstractValidator<SexualHistoryDto>
{
    protected SexualHistoryValidator()
    {
        RuleFor(x => x.ContraceptionMethod).NotEmpty().NotNull().WithMessage("Contraception method is required");
        RuleFor(x => x.SexuallyActive).NotEmpty().NotNull().WithMessage("Sexually active is required");
        RuleFor(x => x.NumberOfPartners).NotEmpty().NotNull().WithMessage("Number of partners active is required");
        RuleFor(x => x.HistoryOfSTIs).NotEmpty().NotNull().WithMessage("History of STIs is required");
    }
}

public abstract class SubstanceUseValidator : AbstractValidator<SubstanceUseDto>
    {
        protected SubstanceUseValidator()
        {
            RuleFor(x => x.Smokes).NotEmpty().NotNull().WithMessage("Smokes is required");
            RuleFor(x => x.AlcoholConsuption).NotEmpty().NotNull()
                .When(x => x.ConsumesAlcohol).WithMessage("Alcohol consumption is required");
            RuleFor(x => x.ConsumesAlcohol).NotEmpty().NotNull().WithMessage("Consume alcohol is required");
            RuleFor(x => x.CigPerDay).NotEmpty().NotNull()
                .When(x => x.Smokes).WithMessage("Cig per day is required");
            RuleFor(x => x.DrugType).NotEmpty().NotNull()
                .When(x => x.UseRecreationalDrugs).WithMessage("Use recreational drugs is required");
        }
    }
public abstract class VaccinationValidator : AbstractValidator<VaccinationDto>
{
    protected VaccinationValidator()
    {
        RuleFor(x => x.VaccineName).NotEmpty().NotNull().WithMessage("Vaccine name is required");
        RuleFor(x => x.DateAdministered).NotEmpty().NotNull().WithMessage("Date administred is required");
    }
}
// public abstract class MedicationValidator : AbstractValidator<MedicationDto>
// {
//     protected MedicationValidator()
//     {
//         RuleFor(x => x.VaccineName).NotEmpty().NotNull().WithMessage("Vaccine name is required");
//         RuleFor(x => x.DateAdministered).NotEmpty().NotNull().WithMessage("Date administred is required");
//     }
// }