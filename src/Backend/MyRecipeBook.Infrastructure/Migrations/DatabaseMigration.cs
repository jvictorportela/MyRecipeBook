﻿using Dapper;
using Microsoft.Data.SqlClient;

namespace MyRecipeBook.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static void Migrate(string connetionString)
    {
        EnsureDatabaseCreated_SqlServer(connetionString);
    }

    private static void EnsureDatabaseCreated_SqlServer(string connetionString)
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder(connetionString);

        var databaseName = connectionStringBuilder.InitialCatalog;

        connectionStringBuilder.Remove("Database");

        using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

        var parameters = new DynamicParameters();
        parameters.Add("name", databaseName);

        var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);

        if (records.Any() == false)
            dbConnection.Execute($"CREATE DATABASE {databaseName}");
    }
}
