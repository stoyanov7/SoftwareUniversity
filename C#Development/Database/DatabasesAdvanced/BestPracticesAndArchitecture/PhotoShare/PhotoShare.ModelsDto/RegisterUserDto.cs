namespace PhotoShare.ModelsDto
{
    using Utilities.Validators;

    public class RegisterUserDto
    {
        public string Username { get; set; }

        [Password(4,20)]
        public string Password { get; set; }       

        [Email]
        public string Email { get; set; }
    }
}
