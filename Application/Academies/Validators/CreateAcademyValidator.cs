using System;
using Application.Academies.Commands;
using FluentValidation;

namespace Application.Academies.Validators;

public class CreateAcademyValidator : AbstractValidator<CreateAcademy.Command>
{
public CreateAcademyValidator()
{
    RuleFor(x=>x.AcademyDto.Name).NotEmpty().WithMessage("Name is required");
    RuleFor(x=>x.AcademyDto.Address).NotEmpty().WithMessage("Address is required");
}
}
