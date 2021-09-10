
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
    public interface IBranchService
    {
        public Task<Response<List<Branch>>> Get();
        public Task<Response<Branch>> Get(int id);
        public Task<Response<Branch>> Create(Branch branch);
    }
    public class BranchService : IBranchService
    {

        private readonly AppSetting _appSetting;
        public BranchService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public async Task<Response<List<Branch>>> Get()
        {
            try
            {
                using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

                var response = await connection.QueryAsync<Branch>(@"SELECT * FROM Branch;");

                var BranchList = response.ToList();
                return new Response<List<Branch>>() { Data = BranchList };
            }
            catch (Exception ex)
            {
                return new Response<List<Branch>>() { Success = false, Message = ex.Message };
            }
        }

        public async Task<Response<Branch>> Get(int id)
        {
            try
            {
                using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

                var BranchList = (await connection.QueryAsync<Branch>(@"SELECT * 
                FROM Branch WHERE Id = @Id;", new { Id = id })).FirstOrDefault();

                return new Response<Branch>() { Data = BranchList };
            }
            catch (Exception ex)
            {
                return new Response<Branch>() { Success = false, Message = ex.Message };
            }
        }


        public async Task<Response<Branch>> Create(Branch branch)
        {
            try
            {
                using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

                var response = await connection.ExecuteAsync(@"INSERT INTO Branch(Name, Address1, Address2, City, Country, ZipCode, MondayStartHour, TuesdayStartHour, WednesdayStartHour, ThursdayStartHour, FridayStartHour, SaturdayStartHour, SundayStartHour, MondayEndHour, TuesdayEndHour, WednesdayEndHour, ThursdayEndHour, FridayEndHour, SaturdayEndHour, SundayEndHour, Services, Created, StatusCode, StatusName)" +
                "VALUES (@Name, @Address1, @Address2, @City, @Country, @ZipCode, @MondayStartHour, @TuesdayStartHour, @WednesdayStartHour, @ThursdayStartHour, @FridayStartHour, @SaturdayStartHour, @SundayStartHour, @MondayEndHour, @TuesdayEndHour, @WednesdayEndHour, @ThursdayEndHour, @FridayEndHour, @SaturdayEndHour, @SundayEndHour, @Services, @Created, @StatusCode, @StatusName)", branch);

                var branchCreated = response == 1;

                return new Response<Branch>() { Success = branchCreated };
            }
            catch (Exception ex)
            {
                return new Response<Branch>() { Success = false, Message = ex.Message };
            }
        }
    }
}
