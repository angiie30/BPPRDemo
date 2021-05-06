
using BPPR_Demo.Helpers;
using BPPR_Demo.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPPR_Demo.Services
{
    public interface IUserService
    {
        public Task<Response<List<User>>> Get();
        public Task<Response<User>> Get(int userId);
        public Task<Response<User>> Create(User user);
        public Task<Response<User>> Update(int userId, string email, string phone, bool active);
    }
    public class UserService : IUserService
    {

        private readonly AppSetting _appSetting;
        public UserService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public async Task<Response<List<User>>> Get()
        {
            try
            {
                using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

                var response = await connection.QueryAsync<User>(@"SELECT Id, FirstName, LastName, Email, Phone, Active 
                FROM User;");

                var userList = response.ToList();
                return new Response<List<User>>() { Data = userList };
            }
            catch (Exception ex)
            {
                return new Response<List<User>>() { Success = false, Message = ex.Message };
            }
        }

        public async Task<Response<User>> Get(int userId)
        {
            try
            {
                using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

                var userList = (await connection.QueryAsync<User>(@"SELECT Id, FirstName, LastName, Email, Phone, Active 
                FROM User WHERE Id = @Id;", new { Id = userId })).FirstOrDefault();

                return new Response<User>() { Data = userList };
            }
            catch (Exception ex)
            {
                return new Response<User>() { Success = false, Message = ex.Message };
            }
        }


        public async Task<Response<User>> Create(User user)
        {
            try
            {
                using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

                var response = await connection.ExecuteAsync(@"INSERT INTO User(FirstName, LastName, Email, Phone, Active)" +
                "VALUES (@FirstName, @LastName, @Email, @Phone, @Active)", user);

                var userCreated = response == 1;

                return new Response<User>() { Success =  userCreated };
            }
            catch (Exception ex)
            {
                return new Response<User>() { Success = false, Message = ex.Message };
            }
        }

        public async Task<Response<User>> Update(int userId, string email, string phone, bool active)
        {
            try
            {
                using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

                var response = await connection.ExecuteAsync(@"UPDATE User
                SET Email = @email, Phone = @phone, Active = @active  
                WHERE Id = @userId", new { userId, email, phone, active});

                var userUpdated = response == 1;

                return new Response<User>() { Success =  userUpdated };
            }
            catch (Exception ex)
            {
                return new Response<User>() { Success = false, Message = ex.Message };
            }
        }


    }
}
