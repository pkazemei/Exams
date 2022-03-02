using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hob.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Hob.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        //Get Index page
        public IActionResult Index()
        {
            HttpContext.Session.Clear(); //Clear session
            return View();
        }

        //Get Dashboard page
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            string username = HttpContext.Session.GetString("UserName");
            User loggedIn = _context.Users.FirstOrDefault(d => d.UserName == username);
            ViewBag.LoggedIn = loggedIn;
            List<Hobby> allHobbies = _context.Hobbies.Include( a => a.Creator ).Include( b => b.AssociatedHob).ToList();
            ViewBag.AllHobbies = allHobbies;
            return View(loggedIn);
        }

        //Get CreateHob page
        [HttpGet("New")]
        public IActionResult CreateHob()
        {
            ViewBag.loggedIn = _context.Users.FirstOrDefault(d => d.UserName == HttpContext.Session.GetString("UserName"));
            return View("CreateHob");
        }

        //Get OneHob page
        [HttpGet("hobby/{hobId}")]
        public IActionResult addOneHob(int hobId)
        {   
            List<Hobby> allHobbies = _context.Hobbies.Include( a => a.Creator ).Include( b => b.AssociatedHob).ToList();
            Hobby OneHob = _context.Hobbies.Include(s => s.AssociatedHob).ThenInclude(d => d.User).FirstOrDefault(a => a.HobbyId == hobId);
            ViewBag.AllHobbies =_context.Hobbies.ToList();
            return View("OneHob", OneHob);
        }

        //Delete Activity
        [HttpGet("hobby/delete/{hobId}")]
        public IActionResult DeleteHob(int hobId)
        {
            Hobby HobToDelete = _context.Hobbies.SingleOrDefault( d => d.HobbyId == hobId);
            _context.Hobbies.Remove(HobToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        //Join Hobby
        [HttpGet("hobby/join/{hobId}/{partId}")]
        public IActionResult Join(int hobId, int partId)
        {
            Association newJoin = new Association();
            newJoin.HobbyId = hobId;
            newJoin.UserId = partId;
            _context.Associations.Add(newJoin);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        //Leave Hobby
        [HttpGet("hobby/leave/{hobId}/{partId}")]
        public IActionResult Leave(int hobId, int partId)
        {
            Association DeletePart = _context.Associations.SingleOrDefault( a => a.HobbyId == hobId && a.UserId == partId);
            _context.Associations.Remove(DeletePart);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        //Post Register User
        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.UserName == newUser.UserName))
                {
                    ModelState.AddModelError("UserName", "User Name already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetString("UserName", newUser.UserName);
                return RedirectToAction("Dashboard");
            } else {
                return View("Index");
            }
        }

        //Post Login User
        [HttpPost("login")]
        public IActionResult Login(LogUser logUser)
        {
            if(ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(s => s.UserName == logUser.LUserName);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LUserName", "Invalid login attempt");
                    return View("Index");
                }
                PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(logUser, userInDb.Password, logUser.LPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LUserName", "Invalid login attempt");
                    return View("Index");
                }
                HttpContext.Session.SetString("UserName", userInDb.UserName);
                return RedirectToAction("Dashboard");
            } else {
                return View("Index");
            }
        }

        //Post Add Hobby
        [HttpPost("addHob")] 
        public IActionResult addHob(Hobby newHob)
        {
            string username = HttpContext.Session.GetString("UserName");
            ViewBag.loggedIn = _context.Users.FirstOrDefault(d => d.UserName == username);
            if(ModelState.IsValid)
            {
                User Creator = _context.Users.FirstOrDefault(d => d.UserName == HttpContext.Session.GetString("UserName"));
                newHob.CreatorId = Creator.UserId;
                _context.Add(newHob);
                _context.SaveChanges();
                Console.WriteLine("Hobby has been added");
                return Redirect($"/hobby/{newHob.HobbyId}");
            } else{
                Console.WriteLine("Hobby was not added");
                return View("CreateHob");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
