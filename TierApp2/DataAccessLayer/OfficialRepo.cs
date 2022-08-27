using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OfficialRepo : IRepository<Official, int>
    {
        MovieWalaDbEntities db;
        public OfficialRepo(MovieWalaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Official obj)
        {
            db.Officials.Add(obj);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var Official = db.Officials.FirstOrDefault(en => en.Id.Equals(id));
            db.Officials.Remove(Official);
            db.SaveChanges();

        }
        public void Edit(Official u)
        {
            var Official = db.Officials.FirstOrDefault(en => en.Id.Equals(u.Id));
            db.Entry(Official).CurrentValues.SetValues(u);
            db.SaveChanges();

        }
        public Official Get(int id)
        {
            return db.Officials.FirstOrDefault(x => x.Id.Equals(id));

        }
        public List<Official> Get()
        {
            return db.Officials.ToList();

        }
  
        
    }
}
