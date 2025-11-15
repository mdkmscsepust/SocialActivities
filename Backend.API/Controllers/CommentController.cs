using Backend.API.Models.Responses;
using Backend.API.Services.CommentService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Comments = await _commentService.GetAllAsync();
            return Ok(Comments);  
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Comment = await _commentService.GetByIdAsync(id);
            if (Comment == null) return NotFound();
            return Ok(Comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentInDto request)
        {
            var result = await _commentService.CreateAsync(request);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CommentInDto request)
        {
            var result = await _commentService.UpdateAsync(id, request);
            if (!result) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _commentService.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}