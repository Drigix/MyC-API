using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.IRepository;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ClubController> _logger;
        private readonly IMapper _mapper;

        public ClubController(IUnitOfWork unitOfWork, ILogger<ClubController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClubs()
        {
            try
            {
                var clubs = await _unitOfWork.Clubs.GetAll();
                var results = _mapper.Map<IList<ClubDTO>>(clubs);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetClubs)}");
                return StatusCode(500, "Internal Server Error, try later");
            }
        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetClub")]
        public async Task<IActionResult> GetClub(int id)
        {
            try
            {
                var club = await _unitOfWork.Clubs.Get(q => q.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<ClubDTO>(club);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetClub)}");
                return StatusCode(500, "Internal Server Error, try later");
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateClub([FromBody] CreateClubDTO clubDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateClub)}");
                return BadRequest(ModelState);
            }
            try
            {
                var club = _mapper.Map<Club>(clubDTO);
                await _unitOfWork.Clubs.Insert(club);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetClub", new { id = club.Id }, club);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateClub)}");
                return StatusCode(500, "Internal Server Error, try later");
            }
        }

        [Authorize]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateClub(int id, [FromBody] UpdateClubDTO clubDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateClub)}");
                return BadRequest(ModelState);
            }
            try
            {
                var club = await _unitOfWork.Clubs.Get(q => q.Id == id);
                if (club == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateClub)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(clubDTO, club);
                _unitOfWork.Clubs.Update(club);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateClub)}");
                return StatusCode(500, "Internal Server Error, try later");
            }

        }


        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteClub(int id)
        {
            if ( id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(DeleteClub)}");
                return BadRequest(ModelState);
            }
            try
            {
                var club = await _unitOfWork.Clubs.Get(q => q.Id == id);
                if (club == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(DeleteClub)}");
                    return BadRequest("Submitted data is invalid");
                }
                await _unitOfWork.Clubs.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteClub)}");
                return StatusCode(500, "Internal Server Error, try later");
            }

        }
    }
}
