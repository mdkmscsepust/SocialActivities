using Backend.API.Models.Entities;
using Backend.API.Services.DonationItemService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationItemController : ControllerBase
    {
        private readonly IDonationItemService _donationItemService;

        public DonationItemController(IDonationItemService donationItemService)
        {
            _donationItemService = donationItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDonationItem([FromBody] DonationItem donationItem)
        {
            var result = await _donationItemService.CreateDonationItemAsync(donationItem);
            if (!result) return BadRequest("Failed to create donation item.");
            
            return Ok("Donation item created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonationItem(int id, [FromBody] DonationItem donationItem)
        {
            var result = await _donationItemService.UpdateDonationItemAsync(id, donationItem);
            if (result)
            {
                return Ok("Donation item updated successfully.");
            }
            return NotFound("Donation item not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonationItem(int id)
        {
            var result = await _donationItemService.DeleteDonationItemAsync(id);
            if (result)
            {
                return Ok("Donation item deleted successfully.");
            }
            return NotFound("Donation item not found.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonationItems()
        {
            var items = await _donationItemService.GetAllDonationItemsAsync();
            return Ok(items);  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonationItemById(int id)
        {
            var item = await _donationItemService.GetDonationItemByIdAsync(id);
            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound("Donation item not found.");
            }   
        }
    }
}