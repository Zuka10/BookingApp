namespace BookingApp.Facade.Repositories;

public interface IUnitOfWork
{
    ICityRepository CityRepository { get; }
    ICountryRepository CountryRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    ISpaRepository SpaRepository { get; }
    ISalonRepository SalonRepository { get; }

    void BeginTransaction();
    void Commit();
    void Rollback();
    void SaveChanges();
    Task SaveChangesAsync();
}