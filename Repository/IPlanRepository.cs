using Models.Context;
using Voting_App.Models;

namespace Voting_App.Repository
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> GetAllPlan();
        Task<Plan> GetPlanByIdAsync(int planId);
        Task<bool> CreatePlanAsync(Plan plan);
        bool UpdatePlan(Plan plan);
        Task<bool> DeletePlanAsync(int planId);
    }

    public class PlanRepository : IPlanRepository
    {

        private readonly Context _context;
        public PlanRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Plan> GetAllPlan()
        {
            return _context.Plans;
        }

        public async Task<Plan> GetPlanByIdAsync(int planId)
        {
            return await _context.Plans.FindAsync(planId);
        }
 
        public async Task<bool> CreatePlanAsync (Plan plan)
        {
            if(plan != null)
            {
                try
                {
                    await _context.AddAsync(plan);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeletePlanAsync(int planId)
        {
            try
            {
                var plan = await _context.Plans.FindAsync(planId);
                if(plan == null)
                {
                    return false;
                }
                DeletePlanByPlan(plan);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePlan(Plan plan)
        {
            if(plan != null)
            {
                try
                {
                    _context.Plans.Update(plan);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private bool DeletePlanByPlan(Plan plan)
        {
            if(plan != null)
            {
                _context.Remove(plan);
                return true;
            }
            return false;
        }

        
    }
}

