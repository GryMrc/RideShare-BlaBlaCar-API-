using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RideShare.DataModels;
using RideShare.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JourneyController : Controller
    {
        private readonly IJournerService _journeyService;
        private readonly IMapper _mapper;

        public JourneyController(IJournerService journerService, IMapper mapper)
        {
            _journeyService = journerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ViewModels.Journey model)
        {
            if (ModelState.IsValid)
            {
                if (model.JourneyDate < DateTime.Now)
                {
                    return Ok(ServiceResponse.FailedResponse("JourneyDate must be bigger than current Date"));
                }

                if (model.SeatNumber <= 0)
                {
                    return Ok(ServiceResponse.FailedResponse("SeatNumber must be bigger than 0"));
                }

                return Ok(await _journeyService.Create(_mapper.Map<DataModels.Journey>(model)));

            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                return Ok(ServiceResponse.FailedResponse(errors.FirstOrDefault()));
            }
        }

        [HttpGet]
        public async Task<IActionResult> List(string departure, string destination)
        {
            if (departure != null && destination != null)
            {
                return Ok(await _journeyService.List(departure, destination));
            }
            else
            {
                return Ok(ServiceResponse.FailedResponse("Required Query Params both departures and destination"));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _journeyService.Delete(Id));
        }

        [HttpGet]
        public async Task<IActionResult> Join(int Id)
        {

            return Ok(await _journeyService.Join(Id));

        }
    }
}
