using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Sk8ter.Api.Models;
using Sk8ter.Application.Tricks.Commands.CreateTrick;
using Sk8ter.Application.Tricks.Commands.DeleteTrick;
using Sk8ter.Application.Tricks.Commands.UpdateTrick;
using Sk8ter.Application.Tricks.Queries.GetAllTricks;
using Sk8ter.Application.Tricks.Queries.GetTrickDetails;
using Sk8ter.Domain.Entities;

namespace Sk8ter.Api.Controllers;
public class TricksController : BaseController
{
    private readonly IMapper _mapper;

    public TricksController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TrickDetailsVm>> GetTrick(int id)
    {
        var query = new GetTrickDetailsQuery { Id = id };
        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet]
    public async Task<ActionResult<TrickListVm>> GetAll()
    {
        var query = new GetTrickListQuery();
        var vm = await Mediator.Send(query);

        return Ok(vm);
    }
    
    [HttpPost]
    public async Task<ActionResult<TrickListVm>> CreateTrick(
        [FromBody] CreateTrickDto trickDto)
    {
        var command = _mapper.Map<CreateTrickCommand>(trickDto);
        var vm = await Mediator.Send(command);

        return Ok(vm);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTrick(int id)
    {
        var query = new DeleteTrickCommand { Id = id };
        var vm = await Mediator.Send(query);

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult<Trick>> UpdateTrick(
        [FromBody] UpdateTrickDto trickDto)
    {
        var command = _mapper.Map<UpdateTrickCommand>(trickDto);
        var vm = await Mediator.Send(command);

        return Ok(vm);
    }
}