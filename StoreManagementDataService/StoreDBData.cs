using Microsoft.Data.SqlClient;
using StoreManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementDataService
{
    public class StoreDBData : IStoreDataService
    {
        private string connectionString = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = WatsonsStoreMgmt; Integrated Security = True; TrustServerCertificate=True;";
        
        private SqlConnection sqlConnection;

        public StoreDBData()
        {
            sqlConnection = new SqlConnection(connectionString);

            AddSeeds();
        }

        private void AddSeeds()
        {
            var existing = GetBranches();

            if (existing.Count == 0)
            {
                StoreModels branch1 = new StoreModels
                {
                    BranchID = 1,
                    BranchName = "WATSONS Pavillion",
                    BranchAddress = "Binan City",
                    BranchContact = "09999999999",
                    BranchIncome = 120000
                };

                StoreModels branch2 = new StoreModels
                {
                    BranchID = 2,
                    BranchName = "WATSONS Galleria",
                    BranchAddress = "San Pedro City",
                    BranchContact = "09998888888",
                    BranchIncome = 300000
                };

                AddBranch(branch1);
                AddBranch(branch2);
            }
        }

        public void AddBranch(StoreModels branch)
        {
            string insertStatement = "INSERT INTO Branches VALUES (@id, @name, @address, @contact, @income)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@id", branch.BranchID);
            insertCommand.Parameters.AddWithValue("@name", branch.BranchName);
            insertCommand.Parameters.AddWithValue("@address", branch.BranchAddress);
            insertCommand.Parameters.AddWithValue("@contact", branch.BranchContact);
            insertCommand.Parameters.AddWithValue("@income", branch.BranchIncome);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<StoreModels> GetBranches()
        {
            string selectStatement = "SELECT * FROM Branches";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var branches = new List<StoreModels>();

            while (reader.Read())
            {
                StoreModels branch = new StoreModels();

                branch.BranchID = Convert.ToInt32(reader["BranchID"]);
                branch.BranchName = reader["BranchName"].ToString();
                branch.BranchAddress = reader["BranchAddress"].ToString();
                branch.BranchContact = reader["BranchContact"].ToString();
                branch.BranchIncome = Convert.ToSingle(reader["BranchIncome"]);

                branches.Add(branch);
            }

            sqlConnection.Close();
            return branches;
        }

        public StoreModels? FindBranch(int id)
        {
            string findStatement = "SELECT * FROM Branches WHERE BranchID = @id";

            SqlCommand findCommand = new SqlCommand(findStatement, sqlConnection);
            findCommand.Parameters.AddWithValue("@id", id);

            sqlConnection.Open();
            SqlDataReader reader = findCommand.ExecuteReader();

            StoreModels? branch = null;

            if (reader.Read())
            {
                branch = new StoreModels
                {
                    BranchID = Convert.ToInt32(reader["BranchID"]),
                    BranchName = reader["BranchName"].ToString(),
                    BranchAddress = reader["BranchAddress"].ToString(),
                    BranchContact = reader["BranchContact"].ToString(),
                    BranchIncome = Convert.ToSingle(reader["BranchIncome"])
                };
            }

            sqlConnection.Close();
            return branch;
        }

        public void UpdateBranch(StoreModels branch)
        {
            sqlConnection.Open();
            var updateStatement = @"UPDATE Branches 
                              SET BranchName = @name,
                                  BranchAddress = @address,
                                  BranchContact = @contact,
                                  BranchIncome = @income
                              WHERE BranchID = @id";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@id", branch.BranchID);
            updateCommand.Parameters.AddWithValue("@name", branch.BranchName);
            updateCommand.Parameters.AddWithValue("@address", branch.BranchAddress);
            updateCommand.Parameters.AddWithValue("@contact", branch.BranchContact);
            updateCommand.Parameters.AddWithValue("@income", branch.BranchIncome);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void RemoveBranch(int id)
        {
            sqlConnection.Open();
            string deleteStatement = "DELETE FROM Branches WHERE BranchID = @id";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@id", id);
            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public bool BranchExists(int id)
        {
            string existsStatement = "SELECT COUNT(*) FROM Branches WHERE BranchID = @id";

            SqlCommand existsCommand = new SqlCommand(existsStatement, sqlConnection);
            existsCommand.Parameters.AddWithValue("@id", id);

            sqlConnection.Open();
            int count = (int)existsCommand.ExecuteScalar();
            sqlConnection.Close();

            return count > 0;
        }
    }
}
