using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ConsumerRepo
    {
        static MovieWalaDbEntities db;

        static ConsumerRepo()
        {
            db = new MovieWalaDbEntities();
        }

        public static List<Consumer> Get()
        {
            return db.Consumers.ToList();
        }

        public static Consumer Get(int id)
        {
            return db.Consumers.Find(id);
        }

        public static Consumer GetConsumerByEmail(string email)
        {
            return db.Consumers.Where(c => c.Email == email).FirstOrDefault();
        }

        public static Consumer GetConsumerByMobile(string mobile)
        {
            return db.Consumers.Where(c => c.Phone == mobile).FirstOrDefault();
        }

        public static Consumer GetConsumerByUserName(string userName)
        {
            return db.Consumers.Where(c => c.Username == userName).FirstOrDefault();
        }

        public static void AddConsumer(Consumer consumer)
        {
            db.Consumers.Add(consumer);
            db.SaveChanges();
        }

        //public static Consumer GetConsumerByUserNameAndPassword(string userName, string password)
        // {
        //      return db.Consumers.Where(c => c.Username == userName && c.Password == password).FirstOrDefault();
        //  }

        public static void Edit(Consumer cm)
        {
            //var ds = db.Consumers.FirstorDefault()
            db.Entry(cm).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteConsumer(Consumer cm)
        {
            db.Entry(cm).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
