using TestProject.Services;
using TestProject.Interfaces;

namespace TestProject
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddTestCreateOfferService (this IServiceCollection services)
        {
            return services.AddTransient<ICreateOffer,TestCreateOffer>();
        }

        public static IServiceCollection AddTestGetOffersService(this IServiceCollection services)
        {
            return services.AddTransient<IGetOffers,TestGetOffers>();
        }

        public static IServiceCollection AddTestGetTop3DistributorsService(this IServiceCollection services)
        {
            return services.AddTransient<IGetTop3Distributors,TestGetTop3Distributors>();
        }

    }
}
