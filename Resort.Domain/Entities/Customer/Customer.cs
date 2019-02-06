using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Rating = new HashSet<Rating>();
            Reservation = new HashSet<Reservation>();
        }

        public long Id { get; set; }
        public string ProfilePhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long TypeId { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string About { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string VerificationStatus { get; set; }
        public DateTime? LastSeen { get; set; }

        public virtual Type Type { get; set; }
        public virtual ExtraInformation ExtraInformation { get; set; }
        public virtual LoginHistory LoginHistory { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual PhoneNumber PhoneNumber { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
