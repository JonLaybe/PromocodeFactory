using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //TODO: Добавить список предпочтений
        public IList<Preference> Preferences { get; set; }
        public IList<PromoCodeShortResponse> PromoCodes { get; set; }
    }
}