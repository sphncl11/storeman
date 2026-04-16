using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using StoreManagementModels;

namespace StoreManagementDataService
{
    public class StoreJsonDataService : IStoreDataService
    {
        private List<StoreModels> branches = new List<StoreModels>();
        private string _jsonFileName;

        public StoreJsonDataService()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Branches.json";
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (branches.Count <= 0)
            {
                branches.Add(new StoreModels
                {
                    BranchID = 1,
                    BranchName = "WATSONS Pavillion",
                    BranchAddress = "Binan City",
                    BranchContact = "09999999999",
                    BranchIncome = 120000
                });

                branches.Add(new StoreModels
                {
                    BranchID = 2,
                    BranchName = "WATSONS Galleria",
                    BranchAddress = "San Pedro City",
                    BranchContact = "09998888888",
                    BranchIncome = 300000
                });

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            string json = JsonSerializer.Serialize(branches, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_jsonFileName, json);
        }

        private void RetrieveDataFromJsonFile()
        {
            if (!File.Exists(_jsonFileName))
            {
                File.Create(_jsonFileName).Close();
                branches = new List<StoreModels>();
                return;
            }

            using (var reader = File.OpenText(_jsonFileName))
            {
                string json = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json))
                {
                    branches = new List<StoreModels>();
                }
                else
                {
                    branches = JsonSerializer.Deserialize<List<StoreModels>>(json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }) ?? new List<StoreModels>();
                }
            }
        }

        public void AddBranch(StoreModels branch)
        {
            RetrieveDataFromJsonFile();
            branches.Add(branch);
            SaveDataToJsonFile();
        }

        public List<StoreModels> GetBranches()
        {
            RetrieveDataFromJsonFile();
            return branches;
        }

        public StoreModels? FindBranch(int id)
        {
            RetrieveDataFromJsonFile();
            return branches.Where(b => b.BranchID == id).FirstOrDefault();
        }

        public void UpdateBranch(StoreModels updatedBranch)
        {
            RetrieveDataFromJsonFile();

            var existing = branches.FirstOrDefault(b => b.BranchID == updatedBranch.BranchID);

            if (existing != null)
            {
                existing.BranchName = updatedBranch.BranchName;
                existing.BranchAddress = updatedBranch.BranchAddress;
                existing.BranchContact = updatedBranch.BranchContact;
                existing.BranchIncome = updatedBranch.BranchIncome;
            }

            SaveDataToJsonFile();
        }

        public void RemoveBranch(int id)
        {
            RetrieveDataFromJsonFile();

            var branch = branches.FirstOrDefault(b => b.BranchID == id);

            if (branch != null)
            {
                branches.Remove(branch);
                SaveDataToJsonFile();
            }
        }

        public bool BranchExists(int id)
        {
            RetrieveDataFromJsonFile();
            return branches.Any(b => b.BranchID == id);
        }
    }
}