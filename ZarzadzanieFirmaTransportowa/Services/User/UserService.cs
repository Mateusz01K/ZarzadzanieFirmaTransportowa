using ZarzadzanieFirmaTransportowa.Context;
using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Models.Users;

namespace ZarzadzanieFirmaTransportowa.Services.User
{
    public class UserService : IUserService
    {
        private readonly CarContext _context;

        public UserService(CarContext context)
        {
            _context = context;
        }

        public void DeleteUser(int id)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChangesAsync();
            }
        }

        public UserModel GetUser(int id)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id);
            return user ?? new UserModel();
        }

        public List<UserModel> GetUser()
        {
            return _context.User.ToList();
        }

        public void InsertUser(string Name, string LastName, string Email)
        {
            var lastId = _context.User.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if (lastId != null)
            {
                _context.User.Add(new UserModel()
                {
                    Id = (int)lastId + 1,
                    Name = Name,
                    LastName = LastName,
                    Email = Email
                });
                _context.SaveChanges();
            }
        }

        public void Updateuser(int id, string Name, string LastName, string Email)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.Name = Name;
                user.LastName = LastName;
                user.Email = Email;
                _context.SaveChanges();
            }
        }
    }
}
