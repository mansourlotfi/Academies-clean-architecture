using System;
using Application.Academies.DTOs;
using FluentValidation;

namespace Application.Academies.Validators;

public class BaseAcademyValidator<T, TDto> : AbstractValidator<T> where TDto : BaseAcademyDto
{
    public BaseAcademyValidator(Func<T,TDto> selector)
    {
    RuleFor(x=>selector(x).Name).NotEmpty().WithMessage("Name is required").MaximumLength(100).WithMessage("Name must not exeed 100 characters");
    RuleFor(x=>selector(x).Address).NotEmpty().WithMessage("Address is required");
    RuleFor(x=>selector(x).Latitude).InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90");
    RuleFor(x=>selector(x).Longitude).InclusiveBetween(-90, 90).WithMessage("Longitude must be between -180 and 180");
        
    }

}
