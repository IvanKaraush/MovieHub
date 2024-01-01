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

        public IReadOnlyCollection<Referral> Referrals => _referrals.AsReadOnly();
        private readonly List<Referral> _referrals = new();

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

        public void AddReferral(string referralName, Guid referralId)
        {
            var referral = _referrals.FirstOrDefault(r => r.ReferralId == referralId);
            if (referral == null)
            {
                _referrals.Add(new Referral(Guid.NewGuid(), referralId, referralName, Name));
            }
            else
            {
                throw new ReferralAlreadyExistException(DomainExceptionMessages.ReferralAlreadyExistFoundException);
            }
        }

        public void RemoveReferral(Guid referralId)
        {
            var referral = _referrals.FirstOrDefault(c => c.ReferralId == referralId);
            if (referral is not null)
            {
                _referrals.Remove(referral);
            }
            else
            {
                throw new ReferralNotFoundException(DomainExceptionMessages.ReferralNotFoundException);
            }
        }
    }
}