namespace PhotoShare.Services
{
    using Contracts;
    using Models;

    public class UserService : IUserService
    {
        public TModel ById<TModel>(int id)
        {
            throw new System.NotImplementedException();
        }

        public TModel ByUsername<TModel>(string username)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string name)
        {
            throw new System.NotImplementedException();
        }

        public User Register(string username, string password, string email)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string username)
        {
            throw new System.NotImplementedException();
        }

        public Friendship AddFriend(int userId, int friendId)
        {
            throw new System.NotImplementedException();
        }

        public Friendship AcceptFriend(int userId, int friendId)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePassword(int userId, string password)
        {
            throw new System.NotImplementedException();
        }

        public void SetBornTown(int userId, int townIde)
        {
            throw new System.NotImplementedException();
        }

        public void SetCurrentTown(int userId, int townId)
        {
            throw new System.NotImplementedException();
        }
    }
}