namespace FDMC.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}