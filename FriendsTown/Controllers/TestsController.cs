using FriendsTown.Models;
using FriendsTown.Transversal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FriendsTown.Controllers
{
    public class TestsController : Controller
    {
        public ContentResult Index()
        {
            string message = "Welcome to FriendsTown " + $"today is {DateTime.Today}";

            return new ContentResult
            {
                Content = message
            };
        }

        public ContentResult Html() 
        {
            return new ContentResult
            {
                Content = "<h1>Welcome to FriendsTown<h1>",
                ContentType = "html"
            };
        }

        public ContentResult Forbidden() 
        {
            return new ContentResult
            {
                StatusCode = 403
            };
        }

        public JsonResult JsonData() 
        {
            var user = new { Id = 1, Name = "Mary" , Age = 35};

            return new JsonResult(user);
        }

        public ContentResult ShowCode(int id) 
        {
            return new ContentResult
            {
                Content = $"Received code: {id}"
            };
        }

        public ContentResult ProcessName(string name) 
        {
            return new ContentResult
            {
                Content = $"Hi: {name} your name has " + $"{name.Length} letters"
            };
        }

        public ContentResult NetPrice(decimal price, decimal discount) 
        {
            decimal calculateDiscount = price * (discount / 100);
            decimal netPrice = price - calculateDiscount;

            return new ContentResult
            {
                Content = $"Price: {price} discount: {calculateDiscount} " + $"Net Price: {netPrice}"
            };
        }

        public ViewResult Welcome() 
        {
            ViewBag.Framework = AppContext.TargetFrameworkName;
            ViewBag.Today = DateTime.Today;
            return View();
        }

        public ViewResult BodyMass(decimal? weight, decimal? height) 
        {
            if (weight is not null && height is not null) 
            {
                ViewBag.Index = weight.Value / (height.Value * height.Value);
            }

            return View();
        }

        public ViewResult Doorman(int age) 
        {
            ViewBag.Age = age;
            return View();
        }

        public ViewResult Multiply(int multiplier) 
        {
            ViewBag.Multiplier = multiplier;
            return View();
        }

        public ViewResult Product() 
        {
            var product = new ProductViewModel
            {
                Code = 2345,
                Name = "Bike",
                Price = 275
            };

            return View(product);
        }

        public ContentResult SendEmail([FromServices] IEmailService emailService) 
        {
            emailService.SendEmail(
                "Administrator@FriendsTown.com",
                "emudjambere@gmail.com",
                "Welcome to FriendsTown",
                "<h3>Hi! New Friend, FriendsTown welcomes you</h3>");

            return new ContentResult
            {
                Content = "Email sent"
            };
        }

        [HttpGet]
        public ViewResult MultipleProducts() 
        {
            return View();
        }

        [HttpPost]
        public ContentResult MultipleProducts(List<string> product) 
        {
            return new ContentResult
            {
                Content = string.Join("-", product)
            };
        }
    }
}
