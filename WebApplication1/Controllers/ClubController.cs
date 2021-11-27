using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            _unitOfWork=unitOfWork;
           _logger=logger;
           _mapper=mapper;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClub(int id)
        {
            try
            {
                var club = await _unitOfWork.Clubs.Get(q=>q.Id==id,new List<string> { "Country"});
                var result = _mapper.Map<ClubDTO>(club);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetClub)}");
                return StatusCode(500, "Internal Server Error, try later");
            }
        }
    }
}
