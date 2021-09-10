using BPPR_Demo.Helpers;
using BPPR_Demo.Services;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPPR_Demo.Database
{
    public interface IDatabaseConfiguration
    {
        void Setup();
    }
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        private readonly AppSetting _appSetting;
        private readonly IBranchService _branchService;

        public DatabaseConfiguration(AppSetting appSetting, IBranchService branchService)
        {
            _appSetting = appSetting;
            _branchService = branchService;
        }

        public void Setup()
        {
            CreateUserTable();
            CreateBranchTable();
            CreateBranchChangeRequestTable();
        }

        private void CreateUserTable()
        {
            using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

            var table = connection.Query<string>(@"SELECT name 
                FROM sqlite_master WHERE type='table' AND name = 'User';").FirstOrDefault();

            if (!string.IsNullOrEmpty(table) && table == "User") return;

            connection.Execute(@"Create Table [User] (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName VARCHAR(50) NOT NULL,
                LastName VARCHAR(50) NOT NULL,
                Email VARCHAR(100) NOT NULL,
                Phone VARCHAR(10) NULL,
                Active BIT NOT NULL DEFAULT 0
            )");
        }
        private void CreateBranchTable()
        {
            using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

            var table = connection.Query<string>(@"SELECT name 
                FROM sqlite_master WHERE type='table' AND name = 'Branch';").FirstOrDefault();

            if (!string.IsNullOrEmpty(table) && table == "Branch") return;

            connection.Execute(@"Create Table [Branch] (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name VARCHAR(250) NOT NULL,
                Address1 VARCHAR(100) NOT NULL,
                Address2 VARCHAR(100) NULL,
                City VARCHAR(50) NOT NULL,
                Country VARCHAR(50) NOT NULL,
                ZipCode VARCHAR(5) NOT NULL,
                MondayStartHour VARCHAR(5) NOT NULL,
                TuesdayStartHour VARCHAR(5) NOT NULL,
                WednesdayStartHour VARCHAR(5) NOT NULL,
                ThursdayStartHour VARCHAR(5) NOT NULL,
                FridayStartHour VARCHAR(5) NOT NULL,
                SaturdayStartHour VARCHAR(5) NOT NULL,
                SundayStartHour VARCHAR(5) NOT NULL,
                MondayEndHour VARCHAR(5) NOT NULL,
                TuesdayEndHour VARCHAR(5) NOT NULL,
                WednesdayEndHour VARCHAR(5) NOT NULL,
                ThursdayEndHour VARCHAR(5) NOT NULL,
                FridayEndHour VARCHAR(5) NOT NULL,
                SaturdayEndHour VARCHAR(5) NOT NULL,
                SundayEndHour VARCHAR(5) NOT NULL,
                Services TEXT NULL,
                StatusCode VARCHAR(2) NOT NULL,
                StatusName VARCHAR(25) NOT NULL,
                Created DATETIME NOT NULL,
                Modified DATETIME NULL
            )");

            SetBranchTable();
        }

        private async void SetBranchTable()
        {
            await _branchService.Create(new Models.Branch
            {
                Name = "San Juan Branch",
                Address1 = "Calle Tetuan 206",
                Address2 = "",
                City = "San Juan",
                Country = "PR",
                ZipCode = "00901",
                MondayStartHour = "8:00 AM",
                MondayEndHour = "4:00 PM",
                TuesdayStartHour = "8:00 AM",
                TuesdayEndHour = "4:00 PM",
                WednesdayStartHour = "8:00 AM",
                WednesdayEndHour = "4:00 PM",
                ThursdayStartHour = "8:00 AM",
                ThursdayEndHour = "4:00 PM",
                FridayStartHour = "8:00 AM",
                FridayEndHour = "4:00 PM",
                SaturdayStartHour = "Closed",
                SaturdayEndHour = "Closed",
                SundayStartHour = "Closed",
                SundayEndHour = "Closed",
                Services = "Sellos y Comprobantes",
                StatusCode = "P",
                StatusName = "Published",
                Created = DateTime.Now
            });

            await _branchService.Create(new Models.Branch
            {
                Name = "Adjuntas Branch",
                Address1 = "Calle San Joaquin 19-21",
                Address2 = "",
                City = "Adjuntas",
                Country = "PR",
                ZipCode = "00601",
                MondayStartHour = "8:00 AM",
                MondayEndHour = "4:00 PM",
                TuesdayStartHour = "8:00 AM",
                TuesdayEndHour = "4:00 PM",
                WednesdayStartHour = "8:00 AM",
                WednesdayEndHour = "4:00 PM",
                ThursdayStartHour = "8:00 AM",
                ThursdayEndHour = "4:00 PM",
                FridayStartHour = "8:00 AM",
                FridayEndHour = "4:00 PM",
                SaturdayStartHour = "Closed",
                SaturdayEndHour = "Closed",
                SundayStartHour = "Closed",
                SundayEndHour = "Closed",
                Services = "Sellos y Comprobantes",
                StatusCode = "P",
                StatusName = "Published",
                Created = DateTime.Now
            });

            await _branchService.Create(new Models.Branch
            {
                Name = "Plaza Las Americas Branch",
                Address1 = "525 Ave. Roosevelt, Plaza Las Americas",
                Address2 = "Primer Nivel",
                City = "San Juan",
                Country = "PR",
                ZipCode = "00918",
                MondayStartHour = "9:00 AM",
                MondayEndHour = "4:00 PM",
                TuesdayStartHour = "9:00 AM",
                TuesdayEndHour = "4:00 PM",
                WednesdayStartHour = "9:00 AM",
                WednesdayEndHour = "4:00 PM",
                ThursdayStartHour = "9:00 AM",
                ThursdayEndHour = "4:00 PM",
                FridayStartHour = "9:00 AM",
                FridayEndHour = "4:00 PM",
                SaturdayStartHour = "9:00 AM",
                SaturdayEndHour = "1:00 PM",
                SundayStartHour = "Closed",
                SundayEndHour = "Closed",
                Services = "Popular Mortgage, Abierto los sábados, Sellos y Comprobantes",
                StatusCode = "P",
                StatusName = "Published",
                Created = DateTime.Now
            });

            await _branchService.Create(new Models.Branch
            {
                Name = "Manatí Popular Center Branch",
                Address1 = "Monte Real Shopping Center, Carretera",
                Address2 = "estate #2 km 45.6, Espacio #5",
                City = "Manatí",
                Country = "PR",
                ZipCode = "00674",
                MondayStartHour = "8:00 AM",
                MondayEndHour = "4:00 PM",
                TuesdayStartHour = "8:00 AM",
                TuesdayEndHour = "4:00 PM",
                WednesdayStartHour = "8:00 AM",
                WednesdayEndHour = "4:00 PM",
                ThursdayStartHour = "8:00 AM",
                ThursdayEndHour = "4:00 PM",
                FridayStartHour = "8:00 AM",
                FridayEndHour = "4:00 PM",
                SaturdayStartHour = "8:00 AM",
                SaturdayEndHour = "12:00 PM",
                SundayStartHour = "Closed",
                SundayEndHour = "Closed",
                Services = "Auto Banco, Abierto los sábados, Sellos y Comprobantes",
                StatusCode = "P",
                StatusName = "Published",
                Created = DateTime.Now
            });

            await _branchService.Create(new Models.Branch
            {
                Name = "Econo Manatí Branch",
                Address1 = "Carr. 670 Km. 1.1, Cordova Davila",
                Address2 = "",
                City = "Manatí",
                Country = "PR",
                ZipCode = "00674",
                MondayStartHour = "8:00 AM",
                MondayEndHour = "4:00 PM",
                TuesdayStartHour = "8:00 AM",
                TuesdayEndHour = "4:00 PM",
                WednesdayStartHour = "8:00 AM",
                WednesdayEndHour = "4:00 PM",
                ThursdayStartHour = "8:00 AM",
                ThursdayEndHour = "4:00 PM",
                FridayStartHour = "8:00 AM",
                FridayEndHour = "4:00 PM",
                SaturdayStartHour = "8:00 AM",
                SaturdayEndHour = "12:00 PM",
                SundayStartHour = "Closed",
                SundayEndHour = "Closed",
                Services = "Auto Banco, Abierto los sábados, Sellos y Comprobantes",
                StatusCode = "P",
                StatusName = "Published",
                Created = DateTime.Now
            }); 

        }


        private void CreateBranchChangeRequestTable()
        {
            using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

            var table = connection.Query<string>(@"SELECT name 
                FROM sqlite_master WHERE type='table' AND name = 'BranchChangeRequest';").FirstOrDefault();

            if (!string.IsNullOrEmpty(table) && table == "BranchChangeRequest") return;

            connection.Execute(@"Create Table [BranchChangeRequest] (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                ChangeRequestId INTEGER NOT NULL,
                StatusCode VARCHAR(2) NOT NULL,
                StatusName VARCHAR(25) NOT NULL,
                MondayStartHour VARCHAR(5) NOT NULL,
                TuesdayStartHour VARCHAR(5) NOT NULL,
                WednesdayStartHour VARCHAR(5) NOT NULL,
                ThursdayStartHour VARCHAR(5) NOT NULL,
                FrydayStartHour VARCHAR(5) NOT NULL,
                SaturdayStartHour VARCHAR(5) NOT NULL,
                SundayStartHour VARCHAR(5) NOT NULL,
                MondayEndHour VARCHAR(5) NOT NULL,
                TuesdayEndHour VARCHAR(5) NOT NULL,
                WednesdayEndHour VARCHAR(5) NOT NULL,
                ThursdayEndHour VARCHAR(5) NOT NULL,
                FrydayEndHour VARCHAR(5) NOT NULL,
                SaturdayEndHour VARCHAR(5) NOT NULL,
                SundayEndHour VARCHAR(5) NOT NULL,
                Services TEXT,
                Created DATETIME NOT NULL,
                Modified DATETIME NOT NULL,
                Approved DATETIME NULL
            )");
        }
    }
}
