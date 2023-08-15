using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lasmart.WebApi.Models.Comment;
using Lasmart.Application.Comments.Commands.CreateComment;
using Lasmart.Application.Comments.Commands.DeleteComment;
using Lasmart.Application.Comments.Commands.UpdateComment;
using Lasmart.Application.Comments.Queries.GetCommentList;


namespace Lasmart.WebApi.Controllers
{
    [Route("api/{controller}/{action}")]   
    public class CommentController : BaseController
    {
        private readonly IMapper _mapper;
        public CommentController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CommentListVm>> GetAll()
        {
            var query = new GetCommentListQuery { };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateCommentDto createCommentDto)
        {
            var command = _mapper.Map<CreateCommentCommand>(createCommentDto);
            var commentId = await Mediator.Send(command);
            return Ok(commentId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCommentDto updateCommentDto)
        {
            var command = _mapper.Map<UpdateCommentCommand>(updateCommentDto);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCommentCommand
            {
                ID = id
            };
            await Mediator.Send(command);
            return Ok();
        }
    }
}
