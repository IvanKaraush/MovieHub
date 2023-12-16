using PersonService.Application.Services.Dto.PersonDto;

namespace PersonService.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonResponse> GetFullPersonByIdAsync(Guid personId);
        Task<PersonResponse> GetPersonByIdAsync(Guid personId);
        Task<Guid> RegistrationAsync(PersonRegisterRequest request);
        Task<Guid> AuthorizationAsync(PersonAuthorizationRequest request);
        Task UpdateAsync(UpdatePersonRequest request);
        Task DeleteAsync(Guid personId);
    }
}