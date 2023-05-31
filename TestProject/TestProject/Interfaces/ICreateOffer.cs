using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface ICreateOffer
    {
        Task<IResult> CreateOffer(Offer offer, ApplicationContext db);
    }
}
