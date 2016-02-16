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

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InmobiliariaGoni.API.Controllers
{
    [Route("api/houses/{houseCode}/images")]
    public class ImagesController : Controller
    {
        private IRealEstateRepository _repository;
        private ILogger<HousesController> _logger;

        public ImagesController(IRealEstateRepository repository, ILogger<HousesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get(string houseCode)
        {
            try
            {
                var houses = _repository.GetHouseByCode(houseCode);
                if (houses == null || houses.Images == null || houses.Images.Count == 0)
                {
                    Response.StatusCode = (int)HttpStatusCode.NoContent;
                    return Json(null);
                }
                
                return Json(Mapper.Map<IEnumerable<ImageViewModel>>(houses.Images.OrderBy(i => i.Order)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get images for house {houseCode}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("An error ocurred finding the house");
            }
            
        }
    }
}