using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Services
{
    public class TestCreateOffer:ICreateOffer
    {
        public async Task<IResult> CreateOffer(Offer offer, ApplicationContext db)
        {
            await db.Offers.AddAsync(offer);
            await db.SaveChangesAsync();
            return Results.Json(offer);
        }
    }
}
