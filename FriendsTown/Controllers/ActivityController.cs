using FriendsTown.Data.Repositories;
using FriendsTown.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using FriendsTown.Domain;

namespace FriendsTown.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository) 
        {
            _activityRepository = activityRepository;
        }
        public IActionResult Index()
        {
            //var model = new List<ActivityViewModel>
            //{
            //    new ActivityViewModel {Id = Guid.NewGuid(), Name = "Climbing", Description = "Climb local peaks"},
            //    new ActivityViewModel {Id = Guid.NewGuid(), Name = "Hiking", Description = "walk through natural trails"},
            //    new ActivityViewModel {Id = Guid.NewGuid(), Name = "Yoga", Description = "Activity in a park"},
            //};

            var activities = _activityRepository.GetAll();

            var model = activities.Select(a => new ActivityViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            });

            return View(model);
        }

        public IActionResult Edit() 
        {
            var model = new ActivityViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Climbing",
                Description = "Climb Local Peaks"
            };

            return View(model);
        }

        public IActionResult Details() 
        {
            var model = new ActivityViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Climbing",
                Description = "Climb local peaks"
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var model = new ActivityViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ActivityViewModel model) 
        {
            var activity = new Activity(Guid.NewGuid());
            activity.Update(model.Name, model.Description);
            _activityRepository.Add(activity);

            return RedirectToAction("Index");
        }
    }
}
