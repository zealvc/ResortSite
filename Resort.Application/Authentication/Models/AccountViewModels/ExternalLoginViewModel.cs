using System;
using System.ComponentModel.DataAnnotations;

namespace Resort.Application.Authentication.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
