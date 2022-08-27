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
    public class OfficialService
    {
        public static List<OfficialModel> Get()
        {
            var data = DataAccessFactory.OfficialDataAccess().Get().Select(c => new OfficialModel
            {
                Id = c.Id,
                Name = c.Name,
                Username = c.Username,
                Dob = c.Dob,
                Type = c.Type,
                Email = c.Email,
                Phone = c.Phone,
            }).ToList();
            return data;
        }

        public static List<string> GetNames()
        {
            var data = DataAccessFactory.OfficialDataAccess().Get().Select(c => c.Name).ToList();
            return data;
        }

        public static void Add(OfficialModel Official)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<OfficialModel, Official>();
                //
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Official>(Official);
            DataAccessFactory.OfficialDataAccess().Add(data);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.OfficialDataAccess().Delete(id);
        }

        public static void Edit(OfficialModel Official)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<OfficialModel, Official>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Official>(Official);
            DataAccessFactory.OfficialDataAccess().Edit(data);
        }
    }
}

