using ITI.DDD.Core;
using ITI.DDD.Infrastructure;
using ITI.DDD.Infrastructure.DataMapping;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Interfaces.RepositoryInterfaces;
using TestApp.DataContext;
using TestApp.DataContext.DataModel;
using TestApp.Domain;
using TestApp.Domain.Identities;

namespace TestApp.Repositories;

public class EfCustomerRepository : Repository<AppDataContext>, ICustomerRepository
{
    public EfCustomerRepository(IUnitOfWorkProvider uow, IDbEntityMapper dbMapper)
        : base(uow, dbMapper)
    {
    }

    private IQueryable<DbCustomer> Aggregate => Context.Customers
        .Include(c => c.LtcPharmacies)
        .AsQueryable();

    public async Task<Customer?> GetAsync(CustomerId id)
    {
        var dbCustomer = await Aggregate.FirstOrDefaultAsync(c => c.Id == id.Guid);

        return dbCustomer != null
            ? DbMapper.ToEntity<Customer>(dbCustomer)
            : null;
    }

    public void Add(Customer customer)
    {
        var dbCustomer = DbMapper.ToDb<DbCustomer>(customer);
        Context.Customers.Add(dbCustomer);
    }

    public async Task RemoveAsync(CustomerId id)
    {
        var dbCustomer = await Aggregate
            .Include(c => c.LtcPharmacies)
            .FirstOrDefaultAsync(c => c.Id == id.Guid);

        if (dbCustomer != null)
        {
            Context.LtcPharmacies.RemoveRange(dbCustomer.LtcPharmacies);
            Context.Customers.Remove(dbCustomer);
        }
    }
}
