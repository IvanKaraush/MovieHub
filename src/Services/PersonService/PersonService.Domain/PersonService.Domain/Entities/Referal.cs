﻿using Ardalis.GuardClauses;
using GuardExtensions;

namespace Domain.Entities
{
    public class Referal : BaseEntity
    {
        public string PersonName
        {
            get => _personName;
            private set
            {
                Guard.Against.SpecialCharacters(value);
                _personName = value;
            }
        }

        private string _personName = null!;

        public string ReferalName
        {
            get => _referalName;
            private set
            {
                Guard.Against.SpecialCharacters(value);
                _referalName = value;
            }
        }

        private string _referalName = null!;

        public Guid ReferalId
        {
            get => _referalId;
            private set
            {
                Guard.Against.Default(value, nameof(value));
                _referalId = value;
            }
        }

        private Guid _referalId;

        public decimal Income { get; private set; }

        public Referal(Guid id, Guid referalId, string referalName, string personName) : base(id)
        {
            ReferalId = referalId;
            ReferalName = referalName;
            PersonName = personName;
        }
    }
}