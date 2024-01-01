using Ardalis.GuardClauses;
using AutoMapper;
using Domain.Entities;
using PersonService.Application.Services.Dto.PersonDto;
using PersonService.Application.Services.Exceptions;
using PersonService.Application.Services.Interfaces;
using PersonService.Application.Services.Primitives;

namespace PersonService.Application.Services.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PersonService(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PersonResponse> GetFullPersonByIdAsync(Guid personId)
    {
        Guard.Against.Default(personId, nameof(personId));

        var person = await _personRepository.GetWithInclude(c => c.Id == personId, c => c.Referrals);
        return _mapper.Map<PersonResponse>(person);
    }

    public async Task<PersonResponse> GetPersonByIdAsync(Guid personId)
    {
        Guard.Against.Default(personId, nameof(personId));

        var person = await _personRepository.GetByIdAsync(personId) ??
                     throw new PersonNotFoundException(ApplicationExceptionMessages.PersonNotFoundException);
        return _mapper.Map<PersonResponse>(person);
    }

    public async Task<Guid> RegistrationAsync(PersonRegisterRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        return await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var person = await _personRepository.GetAsync(c => c.Name == request.Name);
            if (person != null)
            {
                throw new PersonAlreadyExistException(ApplicationExceptionMessages.PersonAlreadyExistException);
            }

            var newPerson = new Person(Guid.NewGuid(), request.Name, request.Email, BCrypt.Net.BCrypt.HashPassword(request.Password),
                request.ProfileCreatedDate);

            if (request.PersonId != null)
            {
                var invitingPerson = await _personRepository.GetWithInclude(c => c.Id == request.PersonId, n => n.Referrals) ??
                                     throw new PersonAlreadyExistException(ApplicationExceptionMessages.PersonAlreadyExistException);

                invitingPerson.AddReferral(newPerson.Name, newPerson.Id);
            }

            _personRepository.Add(newPerson);
            return newPerson.Id;
        });
    }

    public async Task<Guid> AuthorizationAsync(PersonAuthorizationRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var person = await _personRepository.GetAsync(c => c.Name == request.Name) ??
                     throw new PersonNotFoundException(ApplicationExceptionMessages.PersonNotFoundException);

        return person.Id;
    }

    public async Task UpdateAsync(UpdatePersonRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var person = await _personRepository.GetByIdAsync(request.Id) ??
                     throw new PersonNotFoundException(ApplicationExceptionMessages.PersonNotFoundException);

        person.UpdatePerson(request.Name, request.Email, BCrypt.Net.BCrypt.HashPassword(request.Password), request.WalletName);

        await _personRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid personId)
    {
        Guard.Against.Default(personId, nameof(personId));

        var person = await _personRepository.GetByIdAsync(personId) ??
                     throw new PersonNotFoundException(ApplicationExceptionMessages.PersonNotFoundException);

        _personRepository.Delete(person);
        await _personRepository.SaveChangesAsync();
    }
}