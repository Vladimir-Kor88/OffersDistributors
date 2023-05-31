using Microsoft.EntityFrameworkCore;
using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Services
{
    public class TestGetOffers:IGetOffers
    {
        public async Task<IResult> GetOffers(DataOffer data, ApplicationContext db)
        {

            IQueryable<Offer> IQueryOffers = db.Offers.Include(o => o.Distributor).AsNoTracking();

            if (data.Mark != null) IQueryOffers = IQueryOffers.Where(o => o.Mark == data.Mark);

            if (data.Model != null) IQueryOffers = IQueryOffers.Where(o => o.Model == data.Model);

            if (data.Distributor != null) IQueryOffers = IQueryOffers.Where(o => o.Distributor!.Id == data.Distributor.Id);

            var offers = await IQueryOffers.ToListAsync();
            return Results.Json(new DataListOffers { Offers = offers, Count = offers.Count });
        }
    }
}
