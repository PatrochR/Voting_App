using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Voting_App.Models;
using Voting_App.Repository;
using Voting_App.ViewModel;

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
            var plans = _context.Plans.Include(i => i.User);
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
                return View(model);
            }
            var plan = new Plan(){
                Name = model.Name,
                Description = model.Description,
                UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                ModelState.AddModelError("" , "مشکل در ثبت اطلاعات لطفا بعدا تلاش کنید");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int planId)
        {
            var plan = _context.Plans.Find(planId);
            if(plan == null)
            {
                return NotFound();
            }
            if(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) != plan.UserId)
            {
                return NotFound();
            }
            return View(plan);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Plan model)
        {
            if(!ModelState.IsValid || model == null)
            {
                return View(model);
            }
            var plan = await _context.Plans.FindAsync(model.PlanId);
            plan.Name = model.Name;
            plan.Description = model.Description;
            if(plan == null)
            {
                return View(model);
            }
            _context.Plans.Update(plan);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int planId)
        {
            var plan = await _context.Plans.FindAsync(planId);
            if(plan == null)
            {
                return NotFound();
            }
            var viewModel = new PlanDetailsViewModel()
            {
                PlanId = plan.PlanId,
                PlanName = plan.Name,
                PlanDescription = plan.Description,
                Votes = _context.Votes.Where(w => w.PlanId == plan.PlanId).Include(i => i.User).ToList()
            };
            return View(viewModel);
        } 
        
    }
}

