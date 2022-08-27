using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TokenRepo : IRepository<Token, string>
    {
        MovieWalaDbEntities db;

        public TokenRepo(MovieWalaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
        }
        public void Edit(Token e)
        {
            var Token = db.Tokens.FirstOrDefault(en => en.Id.Equals(e.Id));
            db.Entry(Token).CurrentValues.SetValues(e);
            db.SaveChanges();
        }
       
        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }
        
        public void Delete(string id)
        {
            var token = db.Tokens.FirstOrDefault(en => en.Id.Equals(id));
            db.Tokens.Remove(token);
            db.SaveChanges();
        }

        public Token Get(string id)
        {
            return db.Tokens.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
