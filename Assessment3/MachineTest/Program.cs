using Assessment.Repository;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kavya\OneDrive\Documents\NoteTakingApp.mdf;Integrated Security=True;Connect Timeout=30";
            
            var conn=new SqlConnection(connectionString);
            conn.Open();

            //var createTable = @"CREATE TABLE Notes (
            //NoteID INT PRIMARY KEY IDENTITY(1,1),
            //Title NVARCHAR(100) NOT NULL,
            //Content NVARCHAR(MAX) NOT NULL,
            //CreatedAt DATETIME NOT NULL,
            //UpdatedAt DATETIME)";

            //var command = new SqlCommand(createTable, conn);
            //command.ExecuteNonQuery();
            
            conn.Close();
            

            var repository = new NoteRepository(connectionString,log);
            var service = new NoteService(repository,log);
            service.DisplayMenu();

        }
    }
}
