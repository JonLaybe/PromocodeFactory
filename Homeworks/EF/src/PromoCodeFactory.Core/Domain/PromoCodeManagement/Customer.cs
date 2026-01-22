using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Customer
        : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }

        //TODO: Списки Preferences и Promocodes 
        public IList<Preference> Preference { get; set; }

        public IList<PromoCode> PromoCode { get; set; }
    }
}