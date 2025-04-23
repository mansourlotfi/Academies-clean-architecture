using System;
using Application.Academies.Commands;
using Application.Academies.DTOs;
using FluentValidation;

namespace Application.Academies.Validators;

// public class CreateAcademyValidator : AbstractValidator<CreateAcademy.Command>
public class CreateAcademyValidator : BaseAcademyValidator<CreateAcademy.Command, CreateAcademyDto>

{
public CreateAcademyValidator() : base(x=>x.AcademyDto)
{

}
}
