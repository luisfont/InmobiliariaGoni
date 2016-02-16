using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using InmobiliariaGoni.Models;
using System.Net;
using InmobiliariaGoni.API.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using InmobiliariaGoni.Services;
using Microsoft.AspNet.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InmobiliariaGoni.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class HousesController : Controller
    {
        private IRealEstateRepository _repository;
        private ILogger<HousesController> _logger;
        private CoordService _coordService;

        public HousesController(IRealEstateRepository repository, ILogger<HousesController> logger, CoordService coordService)
        {
            _repository = repository;
            _logger = logger;
            _coordService = coordService;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                _logger.LogInformation("User requested houses");
                var houses = _repository.GetAllHouses();
                if (houses != null && houses.Count() > 0)
                {
                    _logger.LogInformation($"User requested houses, {houses.Count()} were found");
                    return Json(Mapper.Map<IEnumerable<HouseViewModel>>(_repository.GetAllHouses()));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.NoContent;
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error returning houses", ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return Json(null);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(Mapper.Map<IEnumerable<HouseViewModel>>(_repository.GetHouseById(id)));
        }

        // POST api/values
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]HouseViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newHouse = Mapper.Map<House>(vm);

                    //Added GeoCoordinates service lookup to the house for the internal map
                    //var coordResult = await _coordService.LookupAsync(newHouse.HouseTitle);

                    //Save to the database and log the information
                    _logger.LogInformation("Saving a new house", newHouse);
                    _repository.AddHouse(newHouse);
                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<HouseViewModel>(newHouse));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new house", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return Json(new { Message = "Failed", ErrorMessage = ex.Message });
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return Json(new { Message = "Failed", ModelState });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
