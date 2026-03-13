using System;
using System.Collections.Generic;
using StoreManagementModels;


namespace StoreManagementDataService
{
    public class StoreDataService
    {
        public List<StoreModels> branches = new List<StoreModels>();

        public void AddBranch(StoreModels branch)
        {
            branches.Add(branch);
        }

        public List<StoreModels> GetBranches()
        {
            return branches;
        }

        public StoreModels FindBranch(int id)
        {
            foreach (StoreModels branch in branches)
            {
                if (branch.BranchID == id)
                {
                    return branch;
                }
            }
            return null;
        }

        public bool DeleteBranch(int id)
        {
            StoreModels branch = FindBranch(id);

            if (branch == null)
                return false;

            branches.Remove(branch);
            return true;
        }
    }
}