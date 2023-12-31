﻿using AutoMapper;
using Domain.Entities;
using PersonService.Application.Services.Dto.PersonDto;
using PersonService.Application.Services.Exceptions;
using PersonService.Application.Services.Interfaces;
using PersonService.Application.Services.Primitives;

namespace PersonService.Application.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonResponse> GetFullPersonByIdAsync(Guid personId)
        {
            var person = await _personRepository.GetWithInclude(c => c.Id == personId, c => c.Referals);
            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<PersonResponse> GetPersonByIdAsync(Guid personId)
        {
            var person = await _personRepository.GetByIdAsync(personId) ??
                         throw new PersonNotFoundException(ApplicationExceptionMessages.PersonNotFoundException);
            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<Guid> RegistrationAsync(PersonRegisterRequest request)
        {
            var person = await _personRepository.GetAsync(c => c.Name == request.Name);
            if (person is not null)
            {
                throw new PersonAlreadyExistException(ApplicationExceptionMessages.PersonAlreadyExistException);
            }

            var newPerson = new Person(Guid.NewGuid(), request.Name, request.Email, request.Password, request.ProfileCreatedDate);
            _personRepository.Add(newPerson);

            await _unitOfWork.SaveChangesAsync();
            return newPerson.Id;
        }

        public async Task<Guid> AuthorizationAsync(PersonAuthorizationRequest request)
        {
            var person = await _personRepository.GetAsync(c => c.Name == request.Name) ??
                         throw new PersonNotFoundException(ApplicationExceptionMessages.PersonNotFoundException);

            return person.Id;
        }

        public async Task UpdateAsync(UpdatePersonRequest request)
        {
            var person = await _personRepository.GetByIdAsync(request.Id) ??
                         throw new PersonNotFoundException(ApplicationExceptionMessages.PersonNotFoundException);

            person.UpdatePerson(request.Name, request.Email, request.Password, request.WalletName);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id) ?? throw new PersonNotFoundException("Такого пользователя не существует");

            _personRepository.Delete(person);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}