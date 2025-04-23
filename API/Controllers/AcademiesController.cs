using System;
using Application.Academies.Commands;
using Application.Academies.DTOs;
using Application.Academies.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AcademiesController : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<Academy>>> GetAcademies(CancellationToken ct)
    {
        return await Mediator.Send(new GetAcademyList.Query(), ct);
    }

    [HttpGet("{id}")]
      public async Task<ActionResult<Academy>> GetAcademyDetails(string id)
    {
        return HandleResult(await Mediator.Send(new GetAcademyDetails.Query{Id = id}));

    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateAcademy(CreateAcademyDto academyDto)
    {
        return HandleResult(await Mediator.Send(new CreateAcademy.Command{AcademyDto = academyDto}));
    }

    
    [HttpPut]
    public async Task<ActionResult> EditAcademy(Academy academy)
    {
         return HandleResult(await Mediator.Send(new EditAcademy.Command{Academy = academy}));

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAcademy(string id)
    {
        return HandleResult(await Mediator.Send(new DeleteAcademy.Command{Id = id}));
    }

}
