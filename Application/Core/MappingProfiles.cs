using System;
using Application.Academies.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Academy, Academy>();
        CreateMap<CreateAcademyDto, Academy>();
        
    }

}
