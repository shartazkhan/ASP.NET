using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepo : IRepository<User, int>, IAuth
    {
        MovieWalaDbEntities db;
        public UserRepo(MovieWalaDbEntities db)
        {
            this.db = db;
        }
        public void Add(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
        }
        public void Edit(User e)
        {
            var User = db.Users.FirstOrDefault(en => en.Sl.Equals(e.Sl));
            db.Entry(User).CurrentValues.SetValues(e);
            db.SaveChanges();
        }
        public void Delete(int Sl)
        {
            var User = db.Users.FirstOrDefault(en => en.Sl.Equals(Sl));
            db.Users.Remove(User);
            db.SaveChanges();
        }
        public User Get(int Sl)
        {
            return db.Users.FirstOrDefault(x => x.Sl.Equals(Sl));
        }
        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public Token Authenticate(User user)
        {
            var u = db.Users.FirstOrDefault(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password));
            Token t = null;
            if (u != null)
            {
                string token = Guid.NewGuid().ToString();
                t = new Token();
                t.UserId = u.Sl;
                t.AccessTocken = token;
                t.CreatedAt = DateTime.Now;
                db.SaveChanges();

                
            }
            return t; 
        }
        
        public bool IsAuthenticated(string token)
        {
            var result = db.Tokens.Any(x => x.AccessTocken.Equals(token) && x.ExpiredAt == null);

            return result;
        }

        public void Logout(string token)
        {
            throw new NotImplementedException();
        }
    }
}
