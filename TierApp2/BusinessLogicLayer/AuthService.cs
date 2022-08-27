using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AuthService
    {
        static AuthService() 
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<UserModel, User>();
                c.CreateMap<Token, TokenModel>();
                c.CreateMap<TokenModel, Token>(); 
                
            });
        }

        public static TokenModel Authinticate(UserModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<UserModel, User>();
                c.CreateMap<Token, TokenModel>();
                c.CreateMap<TokenModel, Token>();
            });
            var mapper = new Mapper(config);
            
            var data = mapper.Map<User>(user);
            var result = DataAccessFactory.AuthDataAccess().Authenticate(data);
            var token = mapper.Map<TokenModel>(result);
            return token;
        }
        public static bool IsAuthenticated(string token)
        {
            var result = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return result;
        }
    } 
}
