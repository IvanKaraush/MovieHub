using Ardalis.GuardClauses;
using GuardExtensions;

namespace Domain.Entities
{
    public class Referral : BaseEntity
    {
        public string PersonName
        {
            get => _personName;
            private set
            {
                Guard.Against.SpecialCharacters(value, nameof(value));
                _personName = value;
            }
        }

        private string _personName = null!;

        public string ReferralName
        {
            get => _referralName;
            private set
            {
                Guard.Against.SpecialCharacters(value, nameof(value));
                _referralName = value;
            }
        }

        private string _referralName = null!;

        public Guid ReferralId
        {
            get => _referralId;
            private set
            {
                Guard.Against.Default(value, nameof(value));
                _referralId = value;
            }
        }

        private Guid _referralId;


        public decimal? Income
        {
            get => _income;
            private set
            {
                Guard.Against.Null(value, nameof(value));
                _income = value;
            }
        }

        private decimal? _income;

        public Referral(Guid id, Guid referralId, string referralName, string personName) : base(id)
        {
            ReferralId = referralId;
            ReferralName = referralName;
            PersonName = personName;
        }
    }
}