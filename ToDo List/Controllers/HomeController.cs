using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDo_List.Entities;
using ToDo_List.Models;

namespace ToDo_List.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Salam";
        }

        public IActionResult UserList()
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Entities", "UserJson.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            var users = JsonConvert.DeserializeObject<List<AppUser>>(jsonData);

            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var user = new AppUser();

            return View(user);
        }


        [HttpPost]
        public IActionResult AddUser(AppUser user)
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Entities", "UserJson.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            var users = JsonConvert.DeserializeObject<List<AppUser>>(jsonData);
            users.Add(user);
            var newJsonData = JsonConvert.SerializeObject(users);
            System.IO.File.WriteAllText(jsonFilePath, newJsonData);

            return RedirectToAction("UserList");
        }

    }
}
