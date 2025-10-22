using MySql.Data.MySqlClient;
using ClubSocialExample.domain.model;
using ClubSocialExample.domain.ports;
using ClubSocialExample.infraestructure.database;
using System;
using System.Data;
using System.Collections.Generic;

namespace ClubSocialExample.infraestructure.adapters.output
{
    public class MySqlGuestPort : GuestPort, IDisposable
    {
        private readonly DatabaseConnection dbConnection;
        private bool disposed = false;

        public MySqlGuestPort()
        {
            dbConnection = DatabaseConnection.Instance;
        }

        public Guest FindByDocument(Guest guest)
        {
            if (guest == null || guest.Document <= 0)
                throw new ArgumentException("Documento de invitado inválido");

            try
            {
                using var connection = dbConnection.GetConnection();
                using var command = new MySqlCommand(
                    @"SELECT p.id, p.name, p.cell_phone, p.document, u.user_name, u.password, u.role,
                             g.partner_id, g.status, g.last_activation_date, g.invitation_count,
                             p2.document as partner_document
                      FROM person p
                      JOIN user u ON u.id = p.id
                      JOIN guest g ON g.id = u.id
                      JOIN partner pt ON pt.id = g.partner_id
                      JOIN person p2 ON p2.id = pt.id
                      WHERE p.document = @document",
                    connection);
                command.Parameters.AddWithValue("@document", guest.Document);

                using var reader = command.ExecuteReader();
                return !reader.Read() ? null : CreateGuestFromReader(reader);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public Guest FindByUserName(Guest guest)
        {
            if (guest == null || string.IsNullOrWhiteSpace(guest.UserName))
                throw new ArgumentException("Nombre de usuario inválido");

            try
            {
                using var connection = dbConnection.GetConnection();
                using var command = new MySqlCommand(
                    @"SELECT p.id, p.name, p.cell_phone, p.document, u.user_name, u.password, u.role,
                             g.partner_id, g.status, g.last_activation_date, g.invitation_count,
                             p2.document as partner_document
                      FROM person p
                      JOIN user u ON u.id = p.id
                      JOIN guest g ON g.id = u.id
                      JOIN partner pt ON pt.id = g.partner_id
                      JOIN person p2 ON p2.id = pt.id
                      WHERE u.user_name = @userName",
                    connection);
                command.Parameters.AddWithValue("@userName", guest.UserName);

                using var reader = command.ExecuteReader();
                return !reader.Read() ? null : CreateGuestFromReader(reader);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public List<Guest> FindGuestsByPartner(Partner partner)
        {
            if (partner == null || partner.Document <= 0)
                throw new ArgumentException("Socio inválido");

            var guests = new List<Guest>();
            try
            {
                using var connection = dbConnection.GetConnection();
                using var command = new MySqlCommand(
                    @"SELECT p.id, p.name, p.cell_phone, p.document, u.user_name, u.password, u.role,
                             g.partner_id, g.status, g.last_activation_date, g.invitation_count,
                             p2.document as partner_document
                      FROM person p
                      JOIN user u ON u.id = p.id
                      JOIN guest g ON g.id = u.id
                      JOIN partner pt ON pt.id = g.partner_id
                      JOIN person p2 ON p2.id = pt.id
                      WHERE p2.document = @partnerDocument",
                    connection);
                command.Parameters.AddWithValue("@partnerDocument", partner.Document);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    guests.Add(CreateGuestFromReader(reader));
                }
                return guests;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public int CountActiveGuestsByPartner(Partner partner)
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
                      WHERE p.document = @partnerDocument AND g.status = true",
                    connection);
                command.Parameters.AddWithValue("@partnerDocument", partner.Document);

                return Convert.ToInt32(command.ExecuteScalar());
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public List<Guest> FindActiveGuests()
        {
            var guests = new List<Guest>();
            try
            {
                using var connection = dbConnection.GetConnection();
                using var command = new MySqlCommand(
                    @"SELECT p.id, p.name, p.cell_phone, p.document, u.user_name, u.password, u.role,
                             g.partner_id, g.status, g.last_activation_date, g.invitation_count,
                             p2.document as partner_document
                      FROM person p
                      JOIN user u ON u.id = p.id
                      JOIN guest g ON g.id = u.id
                      JOIN partner pt ON pt.id = g.partner_id
                      JOIN person p2 ON p2.id = pt.id
                      WHERE g.status = true",
                    connection);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    guests.Add(CreateGuestFromReader(reader));
                }
                return guests;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public bool HasActiveInvitations(Guest guest)
        {
            if (guest == null || guest.Document <= 0)
                throw new ArgumentException("Invitado inválido");

            try
            {
                using var connection = dbConnection.GetConnection();
                using var command = new MySqlCommand(
                    @"SELECT status 
                      FROM guest g
                      JOIN person p ON p.id = g.id
                      WHERE p.document = @document",
                    connection);
                command.Parameters.AddWithValue("@document", guest.Document);

                using var reader = command.ExecuteReader();
                return reader.Read() && reader.GetBoolean("status");
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public void Save(Guest guest)
        {
            if (guest == null)
                throw new ArgumentException("Invitado no puede ser null");

            ValidateGuest(guest);

            using var connection = dbConnection.GetConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                // Insert person
                using (var command = new MySqlCommand(
                    "INSERT INTO person (name, cell_phone, document) VALUES (@name, @cellPhone, @document); SELECT LAST_INSERT_ID();",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@name", guest.Name);
                    command.Parameters.AddWithValue("@cellPhone", guest.CellPhone);
                    command.Parameters.AddWithValue("@document", guest.Document);
                    guest.Id = Convert.ToUInt64(command.ExecuteScalar());
                }

                // Insert user
                using (var command = new MySqlCommand(
                    "INSERT INTO user (id, user_name, password, role) VALUES (@id, @userName, @password, @role)",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", guest.Id);
                    command.Parameters.AddWithValue("@userName", guest.UserName);
                    command.Parameters.AddWithValue("@password", guest.Password);
                    command.Parameters.AddWithValue("@role", guest.Role ?? "guest");
                    command.ExecuteNonQuery();
                }

                // Get partner_id from document
                long partnerId;
                using (var command = new MySqlCommand(
                    "SELECT id FROM person WHERE document = @document",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@document", guest.Partner.Document);
                    var result = command.ExecuteScalar();
                    if (result == null)
                        throw new Exception("El socio especificado no existe");
                    partnerId = Convert.ToInt64(result);
                }

                // Insert guest
                using (var command = new MySqlCommand(
                    @"INSERT INTO guest (id, partner_id, status, last_activation_date, invitation_count) 
                      VALUES (@id, @partnerId, @status, @lastActivationDate, @invitationCount)",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", guest.Id);
                    command.Parameters.AddWithValue("@partnerId", partnerId);
                    command.Parameters.AddWithValue("@status", guest.Status);
                    command.Parameters.AddWithValue("@lastActivationDate", DBNull.Value);
                    command.Parameters.AddWithValue("@invitationCount", 0);
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

        public void Update(Guest guest)
        {
            if (guest == null)
                throw new ArgumentException("Invitado no puede ser null");

            ValidateGuest(guest);

            using var connection = dbConnection.GetConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                // Update person
                using (var command = new MySqlCommand(
                    "UPDATE person SET name = @name, cell_phone = @cellPhone, document = @document WHERE id = @id",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", guest.Id);
                    command.Parameters.AddWithValue("@name", guest.Name);
                    command.Parameters.AddWithValue("@cellPhone", guest.CellPhone);
                    command.Parameters.AddWithValue("@document", guest.Document);
                    if (command.ExecuteNonQuery() == 0)
                        throw new Exception("El invitado no existe");
                }

                // Update user
                using (var command = new MySqlCommand(
                    "UPDATE user SET user_name = @userName, password = @password, role = @role WHERE id = @id",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", guest.Id);
                    command.Parameters.AddWithValue("@userName", guest.UserName);
                    command.Parameters.AddWithValue("@password", guest.Password);
                    command.Parameters.AddWithValue("@role", guest.Role ?? "guest");
                    command.ExecuteNonQuery();
                }

                // Update guest
                using (var command = new MySqlCommand(
                    @"UPDATE guest 
                      SET status = @status,
                          last_activation_date = CASE WHEN @status = true THEN NOW() ELSE last_activation_date END,
                          invitation_count = CASE WHEN @status = true THEN invitation_count + 1 ELSE invitation_count END
                      WHERE id = @id",
                    connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", guest.Id);
                    command.Parameters.AddWithValue("@status", guest.Status);
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

        private Guest CreateGuestFromReader(MySqlDataReader reader)
        {
            return new Guest
            {
                Id = reader.GetUInt64("id"),
                Name = reader.GetString("name"),
                CellPhone = reader.GetInt64("cell_phone"),
                Document = reader.GetInt64("document"),
                UserName = reader.GetString("user_name"),
                Password = reader.GetString("password"),
                Role = reader.GetString("role"),
                Status = reader.GetBoolean("status"),
                Partner = new Partner { Document = reader.GetInt64("partner_document") }
            };
        }

        private void ValidateGuest(Guest guest)
        {
            if (string.IsNullOrWhiteSpace(guest.Name))
                throw new ArgumentException("El nombre es requerido");
            if (guest.Document <= 0)
                throw new ArgumentException("El documento es inválido");
            if (guest.CellPhone <= 0)
                throw new ArgumentException("El número de celular es inválido");
            if (string.IsNullOrWhiteSpace(guest.UserName))
                throw new ArgumentException("El nombre de usuario es requerido");
            if (string.IsNullOrWhiteSpace(guest.Password))
                throw new ArgumentException("La contraseña es requerida");
            if (guest.Partner == null || guest.Partner.Document <= 0)
                throw new ArgumentException("El socio es requerido");
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

        ~MySqlGuestPort()
        {
            Dispose(false);
        }
    }
}