using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface IGetOffers
    {
        Task<IResult> GetOffers(DataOffer data, ApplicationContext db);
    }
}
