using System;
using System.Collections.Generic;
using System.Text;
using StoreManagementModels;

namespace StoreManagementDataService
{
    public interface IStoreDataService
    {
        void AddBranch(StoreModels branch);
        List<StoreModels> GetBranches();
        StoreModels? FindBranch(int id);
        void UpdateBranch(StoreModels branch);
        void RemoveBranch(int id);
        bool BranchExists(int id);
    }
}
