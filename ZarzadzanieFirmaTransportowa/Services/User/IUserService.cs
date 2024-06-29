using ZarzadzanieFirmaTransportowa.Models.Users;

namespace ZarzadzanieFirmaTransportowa.Services.User
{
    public interface IUserService
    {
        public List<UserModel> GetUser();
        public UserModel GetUser(int id);
        public void InsertUser(string Name, string LastName, string Email);
        public void Updateuser(int id, string Name, string LastName, string Email);
        public void DeleteUser(int id);
    }
}
