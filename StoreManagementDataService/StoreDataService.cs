using System;
using System.Collections.Generic;
using StoreManagementModels;


namespace StoreManagementDataService
{
    public class StoreDataService
    {
        private IStoreDataService _storeDataService;

        public StoreDataService(IStoreDataService storeDataService)
        {
            _storeDataService = storeDataService;
        }

        public void AddBranch(StoreModels branch)
        {
            _storeDataService.AddBranch(branch);
        }

        public List<StoreModels> GetBranches()
        {
            return _storeDataService.GetBranches();
        }

        public StoreModels? FindBranch(int id)
        {
            return _storeDataService.FindBranch(id);
        }

        public void UpdateBranch(StoreModels branch)
        {
            _storeDataService.UpdateBranch(branch);
        }

        public void RemoveBranch(int id)
        {
            _storeDataService.RemoveBranch(id);
        }

        public bool BranchExists(int id)
        {
            return _storeDataService.BranchExists(id);
        }
    }
}