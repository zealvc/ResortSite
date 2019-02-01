using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class PaymentMethod
    {
        public long CustomerId { get; set; }
        public int CardNumber { get; set; }
        public long CardTypeId { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string IssuingBank { get; set; }

        public virtual CardType CardType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
