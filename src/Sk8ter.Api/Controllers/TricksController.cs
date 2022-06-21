using Microsoft.AspNetCore.Mvc;
using Sk8ter.Application.Tricks.Commands.CreateTrick;
using Sk8ter.Application.Tricks.Commands.DeleteTrick;
using Sk8ter.Application.Tricks.Commands.UpdateTrick;
using Sk8ter.Application.Tricks.Queries.GetAllTricks;
using Sk8ter.Application.Tricks.Queries.GetTrickDetails;
using Sk8ter.Domain.Entities;
using Sk8ter.Domain.Enums;

namespace Sk8ter.Api.Controllers;
public class TricksController : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TrickDetailsVm>> GetTrick(int id)
    {
        var query = new GetTrickDetailsQuery { Id = id};
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
    public async Task<ActionResult<TrickListVm>> CreateTrick(string name, Difficulty difficulty) 
    {
        var query = new CreateTrickCommand
        {
            Name = name,
            Difficulty = difficulty
        };
        
        var vm = await Mediator.Send(query);

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
        [FromBody] Trick trick)
    {
        var query = new UpdateTrickCommand
        {
            Id = trick.Id,
            Name = trick.Name,
            Difficulty = trick.Difficulty
        };
        var vm = await Mediator.Send(query);

        return Ok(vm);
    }
}