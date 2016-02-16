using InmobiliariaGoni.Models;
using InmobiliariaGoni.Website.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Linq;

namespace InmobiliariaGoni.Website.Controllers
{
    public class AppController : Controller
    {
        private Services.IMailService _mailService;
        private IRealEstateRepository _repository;

        public AppController(Services.IMailService service, IRealEstateRepository dbContext)
        {
            _mailService = service;
            _repository = dbContext;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        //Test view for authorization purposes
        [Authorize]
        [HttpGet]
        public IActionResult Houses()
        {
            var houses = _repository.GetAllHouses();
            return View(houses);
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var emailTo = Startup.Configuration["AppSettings:ContactFormEmails"];
                var emailFrom = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (string.IsNullOrWhiteSpace(emailTo) || string.IsNullOrWhiteSpace(emailFrom))
                {
                    ModelState.AddModelError("", "Could not send email, configuration problem");
                }

                if (_mailService.SendMail(emailTo, emailFrom, $"Contact Page from {model.Name} ({model.Email})", model.Message))
                {
                    ModelState.Clear();
                    ViewBag.Message = "Mail Sent. Thanks";
                }
            }

            return View();
        }
    }
}