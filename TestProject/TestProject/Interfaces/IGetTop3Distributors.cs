namespace TestProject.Interfaces
{
    public interface IGetTop3Distributors
    {
        Task<IResult> GetTop3Distributors(ApplicationContext db);
    }
}
