using ITI.DDD.Application;
using ITI.DDD.Auth;
using ITI.DDD.Core;
using ITI.DDD.Logging;
using TestApp.Application.Dto;
using TestApp.Application.Interfaces;
using TestApp.Application.Interfaces.QueryInterfaces;
using TestApp.Application.Interfaces.RepositoryInterfaces;
using TestApp.Domain;
using TestApp.Domain.Identities;

namespace TestApp.Application;

public class UserAppService : ApplicationService, IUserAppService
{
    private readonly IUserQueries _userQueries;
    private readonly IUserRepository _userRepo;

    public UserAppService(
        IUnitOfWorkProvider uow,
        ILogger logger,
        IAuthContext auth,
        IUserQueries userQueries,
        IUserRepository userRepo
    ) : base(uow, logger, auth)
    {
        _userQueries = userQueries;
        _userRepo = userRepo;
    }

    public Task<UserDto?> GetAsync(UserId id)
    {
        return QueryAsync(
            Authorize.Unauthenticated,
            () => _userQueries.GetAsync(id)
        );
    }

    public async Task<List<UserDto>> ListAsync()
    {
        return await QueryAsync(
            Authorize.Unauthenticated,
            () => _userQueries.ListAsync()
        ) ?? new List<UserDto>();
    }

    public Task<UserId> AddCustomerUserAsync(CustomerId customerId, EmailAddressDto email)
    {
        return CommandAsync(
            Authorize.Unauthenticated,
            () =>
            {
                var customerUser = new CustomerUser(
                    customerId,
                    email.ToValueObject()
                );

                _userRepo.Add(customerUser);
                return Task.FromResult(customerUser.Id);
            }
        );
    }

    public Task<UserId> AddOnCallUserAsync(OnCallProviderId onCallProviderId, EmailAddressDto email)
    {
        return CommandAsync(
            Authorize.Unauthenticated,
            () =>
            {
                var onCallUser = new OnCallUser(
                    onCallProviderId,
                    email.ToValueObject()
                );

                _userRepo.Add(onCallUser);
                return Task.FromResult(onCallUser.Id);
            }
        );
    }
}
