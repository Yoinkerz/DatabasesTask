using Microsoft.EntityFrameworkCore;
using Submission_Task_Datalagring.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Submission_Task_Datalagring.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\HelpdeskDb.mdf;Integrated Security=True;Connect Timeout=30";
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<ErrandEntity> Errands { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;

    }
}
