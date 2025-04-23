using System;
using Application.Academies.Commands;
using FluentValidation;

namespace Application.Academies.Validators;

public class CreateAcademyValidator : AbstractValidator<CreateAcademy.Command>
{
public CreateAcademyValidator()
{
    RuleFor(x=>x.AcademyDto.Name).NotEmpty().WithMessage("Name is required").MaximumLength(100).WithMessage("Name must not exeed 100 characters");
    RuleFor(x=>x.AcademyDto.Address).NotEmpty().WithMessage("Address is required");
    RuleFor(x=>x.AcademyDto.Latitude).InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90");
    RuleFor(x=>x.AcademyDto.Longitude).InclusiveBetween(-90, 90).WithMessage("Longitude must be between -180 and 180");
}
}
