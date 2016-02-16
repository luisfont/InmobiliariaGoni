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
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        private IRealEstateRepository _repository;
        private ILogger<HousesController> _logger;

        public TagsController(IRealEstateRepository repository, ILogger<HousesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}