using TestApp.Application.Dto;
using TestApp.Domain.Identities;

namespace TestApp.Application.Interfaces;

public interface ICustomerAppService
{
    Task<CustomerDto?> GetAsync(CustomerId id);

    Task<CustomerId> AddAsync(
        string name,
        AddressDto? address = null,
        PersonNameDto? contactName = null,
        PhoneNumberDto? contactPhone = null
    );
    Task RemoveAsync(CustomerId id);

    Task SetNameAsync(CustomerId id, string name);
    Task SetContactAsync(CustomerId id, PersonNameDto? contactName, PhoneNumberDto? contactPhone);

    Task AddLtcPharmacyAsync(CustomerId id, string name);
    Task RenameLtcPharmacyAsync(CustomerId id, LtcPharmacyId ltcPharmacyId, string name);
    Task RemoveLtcPharmacyAsync(CustomerId id, LtcPharmacyId ltcPharmacyId);
}
