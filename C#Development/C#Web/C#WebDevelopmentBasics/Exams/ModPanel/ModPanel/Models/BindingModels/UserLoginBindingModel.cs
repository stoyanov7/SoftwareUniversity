namespace ModPanel.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginBindingModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}