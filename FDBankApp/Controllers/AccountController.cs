using FDBankApp.Data.Context;
using FDBankApp.Data.Entities;
using FDBankApp.Data.Interfaces;
using FDBankApp.Data.Repositories;
using FDBankApp.Data.UnitOfWork;
using FDBankApp.Mapping;
using FDBankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FDBankApp.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;
        //public AccountController(IUserMapper userMapper, IApplicationUserRepository applicationUserRepository, IAccountRepository accountRepository, IAccountMapper accountMapper)
        //{
        //    _userMapper = userMapper;
        //    _applicationUserRepository = applicationUserRepository;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}
        //private readonly IGenericRepository<Account> _accountRepository;
        //private readonly IGenericRepository<ApplicationUser> _userRepository;
        //public AccountController(IGenericRepository<ApplicationUser> userRepository, IGenericRepository<Account> accountRepository)
        //{

        //    _userRepository = userRepository;
        //    _accountRepository = accountRepository;
        //}
        private readonly IUow _uow;

        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        public IActionResult Create(int id)
        {
            var userInfo =_uow.GetRepository<ApplicationUser>().GetById(id);

            return View(new UserListModel
            {
                Id=userInfo.Id,
                Name=userInfo.Name,
                Surname=userInfo.Surname
            });
        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _uow.GetRepository<Account>().Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            });
            _uow.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult GetByUserId(int userId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accounts =query.Where(x => x.ApplicationUserId == userId).ToList();
            var user=_uow.GetRepository<ApplicationUser>().GetById(userId);
            ViewBag.FullName = user.Name + " " + user.Surname;
            var list = new List<AccountListModel>();
            foreach(var account in accounts)
            {
                list.Add(new AccountListModel
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUseId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }
            return View(list);
        }
        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query=_uow.GetRepository<Account>().GetQueryable();
            var accounts=query.Where(x=>x.Id!=accountId).ToList();
            var list = new List<AccountListModel>();
            ViewBag.SenderId = accountId;
            foreach(var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUseId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }
            return View(new SelectList(list,"Id","AccountNumber"));
        }
        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            //Uint of Work dizaynpatter
            var senderAccount = _uow.GetRepository<Account>().GetById(model.SenderId);
            senderAccount.Balance -= model.Amount;
            _uow.GetRepository<Account>().Update(senderAccount);
            var account= _uow.GetRepository<Account>().GetById(model.AccountId);
            account.Balance+= model.Amount;
            _uow.GetRepository<Account>().Update(account);
            _uow.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
