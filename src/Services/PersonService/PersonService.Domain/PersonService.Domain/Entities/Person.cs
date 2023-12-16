using Ardalis.GuardClauses;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Primitives;
using Domain.ValueObjects;
using GuardExtensions;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name
        {
            get => _name;
            private set
            {
                Guard.Against.SpecialCharacters(value, nameof(value));
                _name = value;
            }
        }

        private string _name = null!;

        public string Email
        {
            get => _email;
            private set
            {
                Guard.Against.IsEmailValid(value);
                _email = value;
            }
        }

        private string _email = null!;

        public string Password { get; private set; } = null!;

        public decimal Balance { get; private set; }

        public string WalletName
        {
            get => _walletName;
            private set
            {
                Guard.Against.NullOrEmpty(value, nameof(value));
                _walletName = value;
            }
        }

        private string _walletName = null!;

        public ProfileCreationDate ProfileCreationDate { get; private set; } = null!;

        public IReadOnlyCollection<Referal> Referals => _referals.AsReadOnly();
        private readonly List<Referal> _referals = new();

        public Person(Guid id, string name, string email, string password, DateOnly profileCreationDate) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            ProfileCreationDate = new ProfileCreationDate(profileCreationDate);
        }

        private Person(Guid id) : base(id)
        {
        }

        public void UpdatePerson(string name, string email, string password, string walletName)
        {
            Name = name;
            Email = email;
            Password = password;
            WalletName = walletName;
        }

        public void AddReferal(string personName, string referalName, Guid referalId)
        {
            var referal = _referals.FirstOrDefault(r => r.ReferalId == referalId);
            if (referal == null)
            {
                _referals.Add(new Referal(Guid.NewGuid(), referalId, referalName, personName));
            }
            else
            {
                throw new ReferalAlreadyExistException(DomainExceptionMessages.ReferalAlreadyExistFoundException);
            }
        }

        public void RemoveReferal(Guid referalId)
        {
            var referal = _referals.FirstOrDefault(c => c.ReferalId == referalId);
            if (referal is not null)
            {
                _referals.Remove(referal);
            }
            else
            {
                throw new ReferalNotFoundException(DomainExceptionMessages.ReferalNotFoundException);
            }
        }
    }
}