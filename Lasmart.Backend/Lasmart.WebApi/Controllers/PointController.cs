using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lasmart.WebApi.Models.Point;
using Lasmart.Application.Points.Commands.CreatePoint;
using Lasmart.Application.Points.Commands.UpdatePoint;
using Lasmart.Application.Points.Commands.DeletePoint;
using Lasmart.Application.Points.Queries.GetPointList;

namespace Lasmart.WebApi.Controllers
{
    [Route("api/{controller}/{action}")]
    public class PointController : BaseController
    {
        private readonly IMapper _mapper;
        public PointController(IMapper mapper) => _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            var query = new GetPointListQuery { };
            var vm = await Mediator.Send(query);
            return View(vm.Points.ToList());
        }

        [HttpGet]
        public async Task<ActionResult<PointListVm>> GetAll()
        {
            var query = new GetPointListQuery { };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreatePointDto createPointDto)
        {
            var command = _mapper.Map<CreatePointCommand>(createPointDto);           
            var pointId = await Mediator.Send(command);
            return Ok(pointId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdatePointDto updatePointDto)
        {
            var command = _mapper.Map<UpdatePointCommand>(updatePointDto); 
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePointCommand
            {
                ID = id               
            };
            await Mediator.Send(command);
            return Ok();
        }

    }
}