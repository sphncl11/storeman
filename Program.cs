using System;
using System.Collections.Generic;
using StoreManagementAppService;
using StoreManagementModels;


namespace WatsonsStoreManagement
{
    internal class Program
    {
        static StoreAppService appService = new StoreAppService();

        //static List<int> branchIDs = new List<int>();
        //static List<string> branchNames = new List<string>();
        //static List<string> branchAddresses = new List<string>();
        //static List<string> branchContacts = new List<string>();
        //static List<float> branchIncomes = new List<float>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("      WATSONS STORE MANAGEMENT SYSTEM");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("You can select the options below: ");
                Console.WriteLine("1 - Add a Branch");
                Console.WriteLine("2 - View Branches");
                Console.WriteLine("3 - Update a Branch");
                Console.WriteLine("4 - Delete Branch");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("------------------------------------------");
                Console.Write("\nSelect an option: ");
                string optionInput = Console.ReadLine();

                switch (optionInput)
                {
                    case "1":
                        AddBranch();
                        break;
                    case "2":
                        ViewBranches();
                        break;
                    case "3":
                        UpdateBranch();
                        break;
                    case "4":
                        DeleteBranch();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the system...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddBranch()
        {
            Console.Clear();
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("             BRANCH INSERTION");
            Console.WriteLine("------------------------------------------");
            Console.Write("Enter Branch ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Branch Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Contact Number: ");
            string contact = Console.ReadLine();

            Console.Write("Enter Monthly Income: ");
            float income = Convert.ToSingle(Console.ReadLine());

            //branchIDs.Add(id);
            //branchNames.Add(name);
            //branchAddresses.Add(address);
            //branchContacts.Add(contact);
            //branchIncomes.Add(income);

            appService.AddBranch(id, name, address, contact, income);

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Branch added successfully!");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void ViewBranches()
        {
            Console.Clear();
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("              BRANCH LIST");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("ID - BRANCH - ADDRESS - CONTACT NO. - MONTHLY INCOME ");

            var branches = appService.GetBranches();

            foreach (var branch in branches)
            {
                Console.WriteLine(
                    BranchID + " | " +
                    BranchName + " | " +
                    BranchAddress + " | " +
                    BranchContact + " | " +
                    BranchIncome
                );
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void UpdateBranch()
        {
            Console.Clear();

            ViewBranches();

            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("              BRANCH UPDATE");
            Console.WriteLine("------------------------------------------");
            Console.Write("Enter Branch ID to update: ");

            Console.Write("New Branch Name: ");
            string name = Console.ReadLine();

            Console.Write("New Address: ");
            string address = Console.ReadLine();

            Console.Write("New Contact Number: ");
            string contact = Console.ReadLine();

            Console.Write("New Monthly Income: ");
            float income = Convert.ToSingle(Console.ReadLine());

            bool updated = appService.UpdateBranch(id, name, address, contact, income);

            if (!updated)
            {
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("Branch not found.");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            /*else
            {

                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("Branch updated successfully!");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }*/
        }

        static void DeleteBranch()
        {
            Console.Clear();

            ViewBranches();

            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("            BRANCH TERMINATION");
            Console.WriteLine("------------------------------------------");
            Console.Write("Enter Branch ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool deleted = appService.DeleteBranch(id);
            if (!deleted) 
            {
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("Branch not found.");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            //else
            //{
            //Console.WriteLine("\n------------------------------------------");
            //Console.WriteLine("Branch deleted successfully!");
            //Console.WriteLine("------------------------------------------");
            //Console.WriteLine("\nPress any key to continue...");
            //Console.ReadKey();
            //}
        }
    }
}
