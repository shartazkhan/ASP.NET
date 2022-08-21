using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using BusinessLogicLayer.BEnt;

namespace BusinessLogicLayer
{
    public class ConsumerService
    {
        public static List<ConsumerModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Consumer, ConsumerModel>();
                //
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ConsumerModel>>(ConsumerRepo.Get());
            return data;
        }

        public static List<string> GetNames()
        {
            var data = ConsumerRepo.Get().Select(c => c.Name).ToList();
            return data;
        }

        public static void AddConsumer(ConsumerModel consumer)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ConsumerModel, Consumer>();
                //
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Consumer>(consumer);
            ConsumerRepo.AddConsumer(data);
        }

        public static void DeleteConsumer(int id)
        {
            //ConsumerRepo.DeleteConsumer(id);
        }
    }
}
