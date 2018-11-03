namespace Chushka.Models.BindingModels
{
    public class UserRegisterBindingModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}