using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using BusinessEntityLayer;

namespace BusinessLogicLayer
{
    public class ConsumerService
    {
        public static List<ConsumerModel> Get()
        {
            var data = DataAccessFactory.ConsumerDataAccess().Get().Select(c => new ConsumerModel
            {
                Id = c.Id,
                Name = c.Name,
                Username = c.Username,
                Dob = c.Dob,
                Email = c.Email,
                Phone = c.Phone,
                Subscription = c.Subscription,
                ValidationDate = c.ValidationDate,
            }).ToList();
            return data;
        }
        
        public static ConsumerModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Consumer, ConsumerModel>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ConsumerModel>(DataAccessFactory.ConsumerDataAccess().Get(id));
            return data;
        }

        public static List<string> GetNames()
        {
            var data = DataAccessFactory.ConsumerDataAccess().Get().Select(c => c.Name).ToList();
            return data;
        }

        public static void Add(ConsumerModel consumer)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ConsumerModel, Consumer>(); 
                //
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Consumer>(consumer);
            DataAccessFactory.ConsumerDataAccess().Add(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.ConsumerDataAccess().Delete(id);
        }

        public static void Edit(ConsumerModel consumer)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ConsumerModel, Consumer>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Consumer>(consumer);
            DataAccessFactory.ConsumerDataAccess().Edit(data);
        }
    }
}
