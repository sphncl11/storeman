using System;
using System.Collections.Generic;
using StoreManagementDataService;
using StoreManagementModels;


namespace StoreManagementAppService
{
    public class StoreAppService
    {
        StoreDataService storeDataService = new StoreDataService(new StoreDBData());
        //IStoreDataService dataService = new StoreJsonDataService();

        public bool AddBranch(int id, string name, string address, string contact, float income)
        {
            if (storeDataService.FindBranch(id) != null)
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

            storeDataService.AddBranch(branch);
            return true;
        }

        public List<StoreModels> GetBranches()
        {
            return storeDataService.GetBranches();
        }

        public bool BranchExists(int id)
        {
            return storeDataService.FindBranch(id) != null;
        }

        public bool UpdateBranch(int id, string name, string address, string contact, float income)
        {
            var branch = storeDataService.FindBranch(id);

            if (branch == null)
            {
                return false;
            }

            branch.BranchName = name;
            branch.BranchAddress = address;
            branch.BranchContact = contact;
            branch.BranchIncome = income;

            storeDataService.UpdateBranch(branch);

            return true;
        }

        public bool DeleteBranch(int id)
        {
            if (!storeDataService.BranchExists(id))
            {
                return false;
            }

            storeDataService.RemoveBranch(id);
            return true;
        }
    }
}