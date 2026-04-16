using System;
using System.Collections.Generic;
using StoreManagementDataService;
using StoreManagementModels;


namespace StoreManagementAppService
{
    public class StoreAppService
    {
        IStoreDataService dataService = new StoreJsonDataService();

        public bool AddBranch(int id, string name, string address, string contact, float income)
        {
            if (dataService.FindBranch(id) != null)
            {
                return false;
            }

            StoreModels branch = new StoreModels
            {
                BranchID = id,
                BranchName = name,
                BranchAddress = address,
                BranchContact = contact,
                BranchIncome = income
            };

            dataService.AddBranch(branch);
            return true;
        }

        public List<StoreModels> GetBranches()
        {
            return dataService.GetBranches();
        }

        public bool BranchExists(int id)
        {
            return dataService.FindBranch(id) != null;
        }

        public bool UpdateBranch(int id, string name, string address, string contact, float income)
        {
            var branch = dataService.FindBranch(id);

            if (branch == null)
            {
                return false;
            }

            branch.BranchName = name;
            branch.BranchAddress = address;
            branch.BranchContact = contact;
            branch.BranchIncome = income;

            dataService.UpdateBranch(branch);

            return true;
        }

        public bool DeleteBranch(int id)
        {
            if (!dataService.BranchExists(id))
            {
                return false;
            }

            dataService.RemoveBranch(id);
            return true;
        }
    }
}