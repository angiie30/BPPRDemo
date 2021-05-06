using BPPR_Demo.Helpers;
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

        public DatabaseConfiguration(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(_appSetting.BPPRDemoConnectionString);

            var table = connection.Query<string>(@"SELECT name 
                FROM sqlite_master WHERE type='table' AND name = 'User';").FirstOrDefault();

            if (!string.IsNullOrEmpty(table) && table == "User") return;

            connection.Execute(@"Create Table [User] (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName VARCHAR(100) NOT NULL,
                LastName VARCHAR(100) NOT NULL,
                Email VARCHAR(250) NOT NULL,
                Phone VARCHAR(12) NULL,
                Active BIT NOT NULL DEFAULT 0
            )");
        }
    }
}
