using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Voting_App.Models;
using Voting_App.Repository;

namespace Voting_App.Controllers
{
    [Authorize]
    public class PlanController : Controller
    {
        private readonly Context _context;
        private readonly IUserRegister _userRegister;
        public PlanController(Context context , IUserRegister userRegister)
        {
            _context = context;
            _userRegister = userRegister;
        }
        public IActionResult Index()
        {
            var plans = _context.Plans.Include(u => u.PlanToUsers).ThenInclude(t => t.Users);
            return View(plans);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Plan model)
        {  
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(model == null)
            {
                ModelState.AddModelError("" , "اطلاعات ارسال نشد");
                return View(model);
            }
            var plan = new Plan()
            {
                Name = model.Name,
                Description = model.Description
            };
            if(plan == null)
            {
                ModelState.AddModelError("" , "این برنامه وجود ندارد");
                return View(model);
            }
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();
            var user = _userRegister.GetUserByUserName(User.Identity.Name);

            var planTouser = new PlanToUser()
            {
                UserId = user.UserId,
                PlanId = plan.PlanId
            };
            try
            {
            _context.PlanToUsers.Add(planTouser);
            await _context.SaveChangesAsync();
            }
            catch
            {
                return View(model);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}