using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
namespace Lab1.database;

public class FlowerDatabase
{
    private string _connectionString = "Data Source = flowershop.db";

    public FlowerDatabase()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;
            string createQuery =
                "CREATE TABLE IF NOT EXITS flowers(id INTEGER PRIMARY KEY, Name TEXT NOT NULL, PictureURL TEXT NOT NULL)";
            command.CommandText = createQuery;
            command.ExecuteNonQuery();

        }
    }

    public void AddFlower(Flower flower)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;
            string addQuery = "INSERT INTO flowers(Name, PictureURL) VALUES(@Name, @PictureURL)";
            command.CommandText = addQuery;
            command.ExecuteNonQuery();
        }
    }
        
}