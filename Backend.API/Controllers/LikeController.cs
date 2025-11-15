using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.API.Models.Requests;
using Backend.API.Services.LikeService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var likes = await _likeService.GetAllAsync();
            return Ok(likes);  
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var like = await _likeService.GetByIdAsync(id);
            if (like == null) return NotFound();
            return Ok(like);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LikeInDto request)
        {
            var result = await _likeService.CreateAsync(request);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LikeInDto request)
        {
            var result = await _likeService.UpdateAsync(id, request);
            if (!result) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _likeService.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}