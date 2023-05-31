using Microsoft.EntityFrameworkCore;
using TestProject;
using TestProject.Interfaces;
using TestProject.Models;

var builder = WebApplication.CreateBuilder();
string connection = "Server=(localdb)\\mssqllocaldb;Database=applicationdb;Trusted_Connection=True;";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection))
                .AddTestCreateOfferService()
                .AddTestGetOffersService()
                .AddTestGetTop3DistributorsService();
                

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var FirstDist = new Distributor() { Name = "First", CreatedDate = DateTime.Now };
var SecondDist = new Distributor() { Name = "Second", CreatedDate = DateTime.Now };
var ThirdDist = new Distributor() { Name = "Third", CreatedDate = DateTime.Now };
var FourthDist = new Distributor() { Name = "Fourth", CreatedDate = DateTime.Now };
var FifthDist = new Distributor() { Name = "Fifth", CreatedDate = DateTime.Now };

var A = new Offer() { Mark = "A", Model = "A", RegistrationDate = DateTime.Now, Distributor = FifthDist };
var B = new Offer() { Mark = "B", Model = "B", RegistrationDate = DateTime.Now, Distributor = FifthDist };
var C = new Offer() { Mark = "C", Model = "C", RegistrationDate = DateTime.Now, Distributor = FourthDist };
var D = new Offer() { Mark = "D", Model = "D", RegistrationDate = DateTime.Now, Distributor = SecondDist };
var E = new Offer() { Mark = "E", Model = "E", RegistrationDate = DateTime.Now, Distributor = SecondDist };
var F = new Offer() { Mark = "F", Model = "F", RegistrationDate = DateTime.Now, Distributor = FirstDist };
var G = new Offer() { Mark = "G", Model = "G", RegistrationDate = DateTime.Now, Distributor = ThirdDist };
var H = new Offer() { Mark = "H", Model = "H", RegistrationDate = DateTime.Now, Distributor = ThirdDist };
var I = new Offer() { Mark = "I", Model = "I", RegistrationDate = DateTime.Now, Distributor = ThirdDist };
var J = new Offer() { Mark = "J", Model = "J", RegistrationDate = DateTime.Now, Distributor = FourthDist };
var K = new Offer() { Mark = "K", Model = "K", RegistrationDate = DateTime.Now, Distributor = FourthDist };
var L = new Offer() { Mark = "L", Model = "L", RegistrationDate = DateTime.Now, Distributor = FourthDist };
var M = new Offer() { Mark = "M", Model = "M", RegistrationDate = DateTime.Now, Distributor = FifthDist };
var N = new Offer() { Mark = "N", Model = "N", RegistrationDate = DateTime.Now, Distributor = FifthDist };
var O = new Offer() { Mark = "O", Model = "O", RegistrationDate = DateTime.Now, Distributor = FifthDist };

using (ApplicationContext db = new())
{
    db.Distributors.AddRange(FirstDist, SecondDist, ThirdDist, FourthDist, FifthDist);
    db.Offers.AddRange(A, B, C, D, E, F, G, H, I, J, K, L, M, N, O);
    db.SaveChanges();
}

app.MapPost("/api/offer", async (ICreateOffer createOffer, Offer offer, ApplicationContext db) =>
{
    return await createOffer.CreateOffer(offer, db);
});

app.MapGet("/api/offers", async (IGetOffers getOffers, DataOffer data, ApplicationContext db) =>
{
    return await getOffers.GetOffers(data, db);
});

app.MapGet("api/distributors", async (IGetTop3Distributors getTop3Distributors, ApplicationContext db) =>
{
    return await getTop3Distributors.GetTop3Distributors(db);
});

app.Run();
