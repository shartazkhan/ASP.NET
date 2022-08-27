using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ConsumerRepo : IRepository<Consumer, int>
    {
        MovieWalaDbEntities db;
        public ConsumerRepo(MovieWalaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Consumer obj)
        {
            db.Consumers.Add(obj);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var consumer = db.Consumers.FirstOrDefault(en => en.Id.Equals(id));
            db.Consumers.Remove(consumer);
            db.SaveChanges();

        }

        public void Edit(Consumer u)
        {
            var consumer = db.Consumers.FirstOrDefault(en => en.Id.Equals(u.Id));
            db.Entry(consumer).CurrentValues.SetValues(u);
            db.SaveChanges();

        }

        public Consumer Get(int id)
        {
            return db.Consumers.FirstOrDefault(x => x.Id.Equals(id));

        }

        public List<Consumer> Get()
        {
            return db.Consumers.ToList();

        }

        
    }
}
