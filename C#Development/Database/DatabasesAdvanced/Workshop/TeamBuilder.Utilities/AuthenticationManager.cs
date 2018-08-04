namespace TeamBuilder.Utilities
{
    using System;
    using Models;

    public static class AuthenticationManager
    {
        private static User currentUser;

        public static void Authorize()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException("You should login first!");
            }
        }

        public static User GetCurrentUser()
        {
            Authorize();
            return currentUser;
        }

        public static bool IsAuthenticated() => currentUser != null;

        public static void Login(User user)
        {
            currentUser = user ?? 
                          throw new InvalidOperationException("You should logout first!");
        }

        public static void Logout()
        {
            Authorize();
            currentUser = null;
        }
    }
}