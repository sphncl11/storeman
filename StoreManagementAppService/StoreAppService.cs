using System;
using System.Collections.Generic;
using StoreManagementModels;
using StoreManagementDataService;

namespace StoreManagementAppService
{
    public class StoreAppService
    {
        StoreDataService dataService = new StoreDataService();

        public void AddBranch(int id, string name, string address, string contact, float income)
        {
            StoreModels branch = new StoreModels();

            branch.BranchID = id;
            branch.BranchName = name;
            branch.BranchAddress = address;
            branch.BranchContact = contact;
            branch.BranchIncome = income;

            dataService.AddBranch(branch);
        }

        public List<StoreModels> GetBranches()
        {
            return dataService.GetBranches();
        }

        public bool UpdateBranch(int id, string name, string address, string contact, float income)
        {
            StoreModels branch = dataService.FindBranch(id);

            if (branch == null)
                return false;

            branch.BranchName = name;
            branch.BranchAddress = address;
            branch.BranchContact = contact;
            branch.BranchIncome = income;

            return true;
        }

        public bool DeleteBranch(int id)
        {
            return dataService.DeleteBranch(id);
        }
    }
}