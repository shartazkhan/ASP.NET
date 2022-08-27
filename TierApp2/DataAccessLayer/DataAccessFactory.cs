using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        static MovieWalaDbEntities db;
        static DataAccessFactory()
        {
            db = new MovieWalaDbEntities();
        }

        public static IRepository<Consumer, int> ConsumerDataAccess()
        {
            return new ConsumerRepo(db);
        }

        public static IRepository<Official, int> OfficialDataAccess()
        {
            return new OfficialRepo(db); 
        }

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IAuth AuthDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepository<Token, string> TokenDataAccess()
        {
            return new TokenRepo(db);
        }


    }
}
