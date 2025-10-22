using MySql.Data.MySqlClient;
using ClubSocialExample.domain.model;
using ClubSocialExample.domain.ports;
using ClubSocialExample.infraestructure.database;
using System;
using System.Data;

namespace ClubSocialExample.infraestructure.adapters.output
{
    public class MySqlPartnerPort : PartnertPort, IDisposable
    {
        private readonly DatabaseConnection dbConnection;
        private bool disposed = false;

        public MySqlPartnerPort()
        {
            dbConnection = DatabaseConnection.Instance;
        }

        public int CountActiveGuest(Partner partner)
        {
            if (partner == null || partner.Document <= 0)
                throw new ArgumentException("Socio inválido");

            try
            {
                using var connection = dbConnection.GetConnection();
                using var command = new MySqlCommand(
                    @"SELECT COUNT(*) 
                      FROM guest g
                      JOIN partner pt ON pt.id = g.partner_id
                      JOIN person p ON p.id = pt.id
                      WHERE p.document = @document AND g.status = true",
                    connection);
                command.Parameters.AddWithValue("@document", partner.Document);

                return Convert.ToInt32(command.ExecuteScalar());
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public Partner FindByDocument(Partner partner)
        {
            if (partner == null || partner.Document <= 0)
                throw new ArgumentException("Documento de socio inválido");

            try
            {
                using var connection = dbConnection.GetConnection();
                using var command = new MySqlCommand(
                    @"SELECT p.id, p.name, p.cell_phone, p.document, u.user_name, u.password, u.role,
                             pt.amount, pt.type, pt.date_created
                      FROM person p
                      JOIN user u ON u.id = p.id
                      JOIN partner pt ON pt.id = u.id
                      WHERE p.document = @document",
                    connection);
                command.Parameters.AddWithValue("@document", partner.Document);

                using var reader = command.ExecuteReader();
                return !reader.Read() ? null : CreatePartnerFromReader(reader);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public Partner FindByUserName(Partner partner)
        {
            if (partner == null || string.IsNullOrWhiteSpace(partner.UserName))
                throw new ArgumentException("Nombre de usuario inválido");

            try
            {
                using var connection = dbConnection.GetConnection();
                using var command = new MySqlCommand(
                    @"SELECT p.id, p.name, p.cell_phone, p.document, u.user_name, u.password, u.role,
                             pt.amount, pt.type, pt.date_created
                      FROM person p
                      JOIN user u ON u.id = p.id
                      JOIN partner pt ON pt.id = u.id
                      WHERE u.user_name = @userName",
                    connection);
                command.Parameters.AddWithValue("@userName", partner.UserName);

                using var reader = command.ExecuteReader();
                return !reader.Read() ? null : CreatePartnerFromReader(reader);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public void Save(Partner partner)
        {
            if (partner == null)
                throw new ArgumentException("Socio no puede ser null");

            ValidatePartner(partner);

            using var connection = dbConnection.GetConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                // Insert person
                using (var command = new MySqlCommand(
                    "INSERT INTO person (name, cell_phone, document) VALUES (@name, @cellPhone, @document); SELECT LAST_INSERT_ID();",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@name", partner.Name);
                    command.Parameters.AddWithValue("@cellPhone", partner.CellPhone);
                    command.Parameters.AddWithValue("@document", partner.Document);
                    partner.Id = Convert.ToUInt64(command.ExecuteScalar());
                }

                // Insert user
                using (var command = new MySqlCommand(
                    "INSERT INTO user (id, user_name, password, role) VALUES (@id, @userName, @password, @role)",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", partner.Id);
                    command.Parameters.AddWithValue("@userName", partner.UserName);
                    command.Parameters.AddWithValue("@password", partner.Password);
                    command.Parameters.AddWithValue("@role", partner.Role ?? "partner");
                    command.ExecuteNonQuery();
                }

                // Insert partner
                using (var command = new MySqlCommand(
                    "INSERT INTO partner (id, amount, type, date_created) VALUES (@id, @amount, @type, @dateCreated)",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", partner.Id);
                    command.Parameters.AddWithValue("@amount", partner.Amount);
                    command.Parameters.AddWithValue("@type", partner.Type);
                    command.Parameters.AddWithValue("@dateCreated", partner.DateCreated);
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public void Update(Partner partner)
        {
            if (partner == null)
                throw new ArgumentException("Socio no puede ser null");

            ValidatePartner(partner);

            using var connection = dbConnection.GetConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                // Update person
                using (var command = new MySqlCommand(
                    "UPDATE person SET name = @name, cell_phone = @cellPhone, document = @document WHERE id = @id",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", partner.Id);
                    command.Parameters.AddWithValue("@name", partner.Name);
                    command.Parameters.AddWithValue("@cellPhone", partner.CellPhone);
                    command.Parameters.AddWithValue("@document", partner.Document);
                    if (command.ExecuteNonQuery() == 0)
                        throw new Exception("El socio no existe");
                }

                // Update user
                using (var command = new MySqlCommand(
                    "UPDATE user SET user_name = @userName, password = @password, role = @role WHERE id = @id",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", partner.Id);
                    command.Parameters.AddWithValue("@userName", partner.UserName);
                    command.Parameters.AddWithValue("@password", partner.Password);
                    command.Parameters.AddWithValue("@role", partner.Role ?? "partner");
                    command.ExecuteNonQuery();
                }

                // Update partner
                using (var command = new MySqlCommand(
                    "UPDATE partner SET amount = @amount, type = @type, date_created = @dateCreated WHERE id = @id",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", partner.Id);
                    command.Parameters.AddWithValue("@amount", partner.Amount);
                    command.Parameters.AddWithValue("@type", partner.Type);
                    command.Parameters.AddWithValue("@dateCreated", partner.DateCreated);
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private Partner CreatePartnerFromReader(MySqlDataReader reader)
        {
            return new Partner
            {
                Id = reader.GetUInt64("id"),
                Name = reader.GetString("name"),
                CellPhone = reader.GetInt64("cell_phone"),
                Document = reader.GetInt64("document"),
                UserName = reader.GetString("user_name"),
                Password = reader.GetString("password"),
                Role = reader.GetString("role"),
                Amount = reader.GetDouble("amount"),
                Type = reader.GetString("type"),
                DateCreated = reader.GetDateTime("date_created")
            };
        }

        private void ValidatePartner(Partner partner)
        {
            if (string.IsNullOrWhiteSpace(partner.Name))
                throw new ArgumentException("El nombre es requerido");
            if (partner.Document <= 0)
                throw new ArgumentException("El documento es inválido");
            if (partner.CellPhone <= 0)
                throw new ArgumentException("El número de celular es inválido");
            if (string.IsNullOrWhiteSpace(partner.UserName))
                throw new ArgumentException("El nombre de usuario es requerido");
            if (string.IsNullOrWhiteSpace(partner.Password))
                throw new ArgumentException("La contraseña es requerida");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbConnection.CloseConnection();
                }
                disposed = true;
            }
        }

        ~MySqlPartnerPort()
        {
            Dispose(false);
        }
    }
}