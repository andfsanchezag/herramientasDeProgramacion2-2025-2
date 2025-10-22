using MySql.Data.MySqlClient;
using System;
using System.Threading;

namespace ClubSocialExample.infraestructure.database
{
    public class DatabaseConnection
    {
        private static DatabaseConnection instance;
        private readonly string connectionString;
        private static readonly object lockObject = new();
        private readonly ThreadLocal<MySqlConnection> threadLocalConnection;

        private DatabaseConnection()
        {
            connectionString = "Server=localhost;Port=3306;Database=club_social;User=root;Password=;";
            threadLocalConnection = new ThreadLocal<MySqlConnection>();
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new DatabaseConnection();
                    }
                }
                return instance;
            }
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = threadLocalConnection.Value;
                
                if (connection == null)
                {
                    connection = new MySqlConnection(connectionString);
                    threadLocalConnection.Value = connection;
                }

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                return connection;
            }
            catch (MySqlException ex) when (ex.Number == 1049) // Database doesn't exist
            {
                CreateDatabase();
                var connection = new MySqlConnection(connectionString);
                threadLocalConnection.Value = connection;
                connection.Open();
                return connection;
            }
        }

        public void CloseConnection()
        {
            if (threadLocalConnection.Value != null)
            {
                threadLocalConnection.Value.Close();
                threadLocalConnection.Value.Dispose();
                threadLocalConnection.Value = null;
            }
        }

        private void CreateDatabase()
        {
            string createDbConnectionString = "Server=localhost;Port=3306;User=root;Password=;";
            using var tempConnection = new MySqlConnection(createDbConnectionString);
            tempConnection.Open();

            using var command = new MySqlCommand(GetCreateDatabaseScript(), tempConnection);
            command.ExecuteNonQuery();
        }

        private string GetCreateDatabaseScript()
        {
            return @"
                DROP DATABASE IF EXISTS club_social;
                CREATE DATABASE club_social;
                USE club_social;

                CREATE TABLE person (
                    id BIGINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
                    name VARCHAR(100) NOT NULL,
                    cell_phone BIGINT NOT NULL,
                    document BIGINT NOT NULL,
                    UNIQUE KEY uk_document (document)
                );

                CREATE TABLE user (
                    id BIGINT UNSIGNED PRIMARY KEY,
                    user_name VARCHAR(50) NOT NULL,
                    password VARCHAR(100) NOT NULL,
                    role VARCHAR(20) NOT NULL,
                    FOREIGN KEY (id) REFERENCES person(id) ON DELETE CASCADE,
                    UNIQUE KEY uk_user_name (user_name)
                );

                CREATE TABLE partner (
                    id BIGINT UNSIGNED PRIMARY KEY,
                    amount DOUBLE NOT NULL,
                    type VARCHAR(20) NOT NULL,
                    date_created DATETIME NOT NULL,
                    FOREIGN KEY (id) REFERENCES user(id) ON DELETE CASCADE
                );

                CREATE TABLE guest (
                    id BIGINT UNSIGNED PRIMARY KEY,
                    partner_id BIGINT UNSIGNED NOT NULL,
                    status BOOLEAN NOT NULL DEFAULT FALSE,
                    last_activation_date DATETIME NULL,
                    invitation_count INT DEFAULT 0,
                    FOREIGN KEY (id) REFERENCES user(id) ON DELETE CASCADE,
                    FOREIGN KEY (partner_id) REFERENCES partner(id) ON DELETE CASCADE,
                    INDEX idx_partner_status (partner_id, status),
                    INDEX idx_status (status),
                    INDEX idx_activation_date (last_activation_date)
                );";
        }
    }
}