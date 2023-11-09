using BookingApp.Facade.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace BookingApp.Repository;

public class UnitOfWork
{
    private IDbContextTransaction? _transaction;
    private readonly BookingAppDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly Lazy<ICountryRepository> _countryRepository;
    private readonly Lazy<ISpaRepository> _spaRepository;
    private readonly Lazy<ICityRepository> _cityRepository;
    private readonly Lazy<ISalonRepository> _salonRepository;
    private readonly Lazy<ICustomerRepository> _customerRepository;

    public UnitOfWork(BookingAppDbContext context, ILogger<UnitOfWork> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _spaRepository = new Lazy<ISpaRepository>(() => new SpaRepository(context));
        _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(context));
        _salonRepository = new Lazy<ISalonRepository>(() => new SalonRepository(context));
        _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(context));
        _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
    }

    public ISpaRepository SpaRepository => _spaRepository.Value;
    public ISalonRepository SalonRepository => _salonRepository.Value;
    public ICityRepository CityRepository => _cityRepository.Value;
    public ICountryRepository CountryRepository => _countryRepository.Value;
    public ICustomerRepository CustomerRepository => _customerRepository.Value;

    public void BeginTransaction()
    {
        try
        {
            _transaction = _context.Database.BeginTransaction();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to begin transaction");
            throw;
        }
    }

    public void Commit()
    {
        try
        {
            _transaction?.Commit();
            _transaction?.Dispose();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to commit transaction");
            throw;
        }
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
    }

    public void SaveChanges()
    {
        try
        {
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DbContext error");
            throw;
        }

    }

    public void Dispose()
    {
        try
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to rollback transaction");
            throw;
        }
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DbContext error");
            throw;
        }
    }
}