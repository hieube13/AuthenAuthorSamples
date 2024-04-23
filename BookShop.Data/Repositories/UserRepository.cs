using BookShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookShopDbContext _context;

        public UserRepository(BookShopDbContext context)
        {
            _context = context;

            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    FullName = "Cristiano Ronaldo",
                    UserName = "CR7",
                    //Password = "e50de92f25c5466fb5771650ad2eece2ffeefe1e81dd9fa2d2533510f196cc",
                    Password = "123456",
                    FavoriteColor = "Pink",
                    Role = "Admin",
                    GoogleId = "113026506493776389813"
                });

                _context.SaveChanges();
            }
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            //var hashPWD = ComputeSha256Hash(password);
            var user = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);

            return user;
        }

        //private string ComputeSha256Hash(string password)
        //{
        //    using(SHA256 sha256Hash = SHA256.Create())
        //    {
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        //        StringBuilder builder = new StringBuilder();

        //        for(int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }

        //        return builder.ToString();
        //    }
        //}

        public User GetUserByGoogleIdentifier(string googleId)
        {
            var user = _context.Users.FirstOrDefault(x => x.GoogleId == googleId);

            return user;
        }
    }

    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetUserByGoogleIdentifier(string googleId);
    }
}
