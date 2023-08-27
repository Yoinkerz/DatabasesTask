
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Submission_Task_Datalagring.Models.Entities;

namespace Submission_Task_Datalagring.Services
{
    internal class DatabaseService
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\local_db.mdf;Integrated Security=True;Connect Timeout=30";

        public DbSet<CustomerEntity> CustomerEntities { get; set; } = null!;
        public DbSet<ErrandEntity> ErrandEntities { get; set; } = null!;

        public void SaveCustomerToDatabase(CustomerEntity customer)
        {
            customer = new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };

            SaveCustomer(customer);
        }

        public void SaveErrandToDatabase(ErrandEntity errand)
        {
            errand = new ErrandEntity
            {
                Description = errand.Description,
                CurrentTime = errand.CurrentTime,
                Status = errand.Status,
            };

            SaveErrand(errand);
        }


        public void SaveErrand(ErrandEntity errandEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            

            using var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Errands WHERE Description = @Description) INSERT INTO Errands VALUES (@Description, @CurrentTime, @Status)", conn);
            cmd.Parameters.AddWithValue("@Description", errandEntity.Description);
            cmd.Parameters.AddWithValue("@CurrentTime", errandEntity.CurrentTime);
            cmd.Parameters.AddWithValue("@Status", errandEntity.Status);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void SaveCustomer(CustomerEntity customerEntity)
        {
            using var conn = new SqlConnection(_connectionString);

            using var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email) INSERT INTO Customers VALUES (@FirstName, @LastName, @Email, @PhoneNumber)", conn);
            cmd.Parameters.AddWithValue("@FirstName", customerEntity.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customerEntity.LastName);
            cmd.Parameters.AddWithValue("@Email", customerEntity.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", customerEntity.PhoneNumber);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}
