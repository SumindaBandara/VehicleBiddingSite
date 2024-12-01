using BidNest.DTOs;
using BidNest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BidNest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST /api/users/profile
        [HttpPost("profile")]
        public async Task<IActionResult> CreateOrUpdateProfile([FromBody] UserProfileDto dto)
        {
            try
            {
                var existingUser = await _context.Users.FindAsync(dto.ClerkUserId);

                if (existingUser == null)
                {
                    var newUser = new User
                    {
                        ClerkUserId = dto.ClerkUserId,
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Email = dto.Email,
                        Phone = dto.Phone,
                        Address = dto.Address,
                        City = dto.City,
                        State = dto.State,
                        ZipCode = dto.ZipCode,
                        DrivingLicense = dto.DrivingLicense,
                        PreferredBidType = dto.PreferredBidType,
                        BidderType = dto.BidderType
                    };

                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Profile created successfully", user = newUser });
                }

                // Update existing user
                existingUser.FirstName = dto.FirstName;
                existingUser.LastName = dto.LastName;
                existingUser.Email = dto.Email;
                existingUser.Phone = dto.Phone;
                existingUser.Address = dto.Address;
                existingUser.City = dto.City;
                existingUser.State = dto.State;
                existingUser.ZipCode = dto.ZipCode;
                existingUser.DrivingLicense = dto.DrivingLicense;
                existingUser.PreferredBidType = dto.PreferredBidType;
                existingUser.BidderType = dto.BidderType;
                existingUser.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Profile updated successfully", user = existingUser });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error processing request", error = ex.Message });
            }
        }

        // GET /api/users/profile/{clerkUserId}
        [HttpGet("profile/{clerkUserId}")]
        public async Task<IActionResult> GetProfile(string clerkUserId)
        {
            var user = await _context.Users.FindAsync(clerkUserId);
            if (user == null)
            {
                return NotFound(new { message = "Profile not found" });
            }

            return Ok(user);
        }
    }
}