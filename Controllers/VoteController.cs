using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Models.Context;
using Voting_App.Models;


namespace Voting_App.Controllers
{
    public class VoteController : Controller
    {
        private readonly Context _context;
        public VoteController(Context context)
        {
            _context = context;
        }



        public IActionResult Create(int planId)
        {
            ViewBag.planId = planId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Vote model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(model == null)
            {
                return View(model);
            }
            var user = _context.Users.Find(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var vote = new Vote()
            {
                VoteData = model.VoteData,
                DayTime = model.DayTime,
                PlanId = model.PlanId,
                User = user,
                UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            };
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();


            return Redirect($"/Plan/Details?planId={vote.PlanId}");
        }

        public async Task<IActionResult> Delete(int voteId)
        {   
            var vote = _context.Votes.Find(voteId);
            if(vote == null)
            {
                return NotFound();
            }
            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();
            return Redirect($"/Plan/Details?planId={vote.PlanId}");
        }
    }
}