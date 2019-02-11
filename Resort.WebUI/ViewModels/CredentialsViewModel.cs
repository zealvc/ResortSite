 
using Resort.WebUI.ViewModels.Validations;
//using FluentValidation.Attributes;

namespace Resort.WebUI.ViewModels
{
  //[Validator(typeof(CredentialsViewModelValidator))]   
  public class CredentialsViewModel
  {
    public string UserName { get; set; }
    public string Password { get; set; }
  }
}
