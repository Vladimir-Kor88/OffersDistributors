using Microsoft.EntityFrameworkCore;
using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Services
{
    public class TestGetTop3Distributors:IGetTop3Distributors
    {
        public async Task<IResult> GetTop3Distributors(ApplicationContext db)
        {
            var distributors = (from o in db.Offers.Include(o => o.Distributor).AsNoTracking()
                                group o by o.Distributor into g
                                orderby g.Count() descending
                                select new DataDistributor { Name = g.Key.Name, Offers = g.Count() })
                        .Take(3);
            var listDistributors = await distributors.ToListAsync();
            return Results.Json(listDistributors);
        }
    }
}
