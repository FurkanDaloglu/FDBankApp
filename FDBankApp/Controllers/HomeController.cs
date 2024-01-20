using FDBankApp.Data.Context;
using FDBankApp.Data.Entities;
using FDBankApp.Data.Interfaces;
using FDBankApp.Data.Repositories;
using FDBankApp.Data.UnitOfWork;
using FDBankApp.Mapping;
using FDBankApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FDBankApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;
        public HomeController(ILogger<HomeController> logger,/* IApplicationUserRepository applicationUserRepository,*/ IUserMapper userMapper, IUow uow)
        {
            _logger = logger;
            //_applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_uow.GetRepository<ApplicationUser>().GetAll()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
