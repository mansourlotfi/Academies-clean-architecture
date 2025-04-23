using System;
using Application.Academies.Commands;
using Application.Academies.DTOs;
using FluentValidation;

namespace Application.Academies.Validators;

public class EditAcademyValidator : BaseAcademyValidator<EditAcademy.Command, EditAcademyDto>
{
    public EditAcademyValidator() : base(x => x.AcademyDto)
    {
        RuleFor(x => x.AcademyDto.Id).NotEmpty().WithMessage("Id is required");
    }
}
