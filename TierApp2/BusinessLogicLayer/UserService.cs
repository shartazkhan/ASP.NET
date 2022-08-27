using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessEntityLayer;
using AutoMapper;

namespace BusinessLogicLayer
{
    public class UserService
    {
        public static List<UserModel> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get().Select(c => new UserModel
            {
                Sl = c.Sl,
                Username = c.Username,
                Type = c.Type,
                Password = c.Password,
            }).ToList();
            return data;
        }

        public static UserModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<UserModel>(DataAccessFactory.UserDataAccess().Get(id));
            return data;
        }
        public static List<string> GetNames()
        {
            var data = DataAccessFactory.UserDataAccess().Get().Select(u => u.Username).ToList();
            return data;
        }
        public static void Add(UserModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
                c.CreateMap<ConsumerModel, Consumer>();
                c.CreateMap<OfficialModel, Official>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);
            DataAccessFactory.UserDataAccess().Add(data);
        }
        public static void Delete(int id)
        {
            DataAccessFactory.UserDataAccess().Delete(id);
        }
        public static void Edit(UserModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
                c.CreateMap<ConsumerModel, Consumer>();
                c.CreateMap<OfficialModel, Official>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);
            DataAccessFactory.UserDataAccess().Edit(data);
        }
    }
}
