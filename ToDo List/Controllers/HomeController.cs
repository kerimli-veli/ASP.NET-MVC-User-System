using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ToDo_List.Entities;

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
            string filePath = "UserJson.json";  

            string UserJson = System.IO.File.ReadAllText(filePath);

            List<User> users = JsonSerializer.Deserialize<List<User>>(UserJson);

            return View(users);
        }
    }
}
