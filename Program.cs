using System;
using System.Collections.Generic;

namespace WatsonsStoreManagement
{
    internal class Program
    {
        static List<string> branches = new List<string>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("WELCOME TO WATSONS STORE MANAGEMENT SYSTEM");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("You can select the options below: ");
                Console.WriteLine("1 - Add a Branch");
                Console.WriteLine("2 - View Branches");
                Console.WriteLine("3 - Update a Branch");
                Console.WriteLine("4 - Delete Branch");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("------------------------------------------");
                Console.Write("Select an option: ");
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

        //contact and income should be numeric only,
        //but for simplicity, we will keep them as strings in this example.
        //In a real application, you would want to validate these inputs and
        //possibly use a more structured data format (like a class or struct)
        //to represent branches.
        static void AddBranch()
        {
            Console.Clear();
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("             BRANCH INSERTION");
            Console.WriteLine("------------------------------------------");
            Console.Write("Enter Branch Name: ");
            string branchName = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Contact Number: ");
            string contact = Console.ReadLine();

            Console.Write("Enter Monthly Income: ");
            string income = Console.ReadLine();

            int id = branches.Count + 1;

            string branchData = id + " | " + branchName + " | " + address + " | " + contact + " | " + income;
            branches.Add(branchData);
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

            if (branches.Count == 0)
            {
                Console.WriteLine("No branches available.");
                return;
            }

            foreach (var branch in branches)
            {
                Console.WriteLine(branch);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void UpdateBranch()
        {
            Console.Clear();
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("              BRANCH UPDATE");
            Console.WriteLine("------------------------------------------");
            Console.Write("Enter Branch ID to update: ");
            string id = Console.ReadLine();

            for (int i = 0; i < branches.Count; i++)
            {
                if (branches[i].StartsWith(id + " |"))
                {
                    Console.WriteLine("------------------------------------------");
                    Console.Write("New Branch Name: ");
                    string name = Console.ReadLine();
                    Console.Write("New Address: ");
                    string address = Console.ReadLine();
                    Console.Write("New Contact Number: ");
                    string contact = Console.ReadLine();
                    Console.Write("New Monthly Income: ");
                    string income = Console.ReadLine();

                    branches[i] = id + " | " + name + " | " + address + " | " + contact + " | " + income;

                    Console.WriteLine("\n------------------------------------------");
                    Console.WriteLine("Branch updated successfully!");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Branch not found.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void DeleteBranch()
        {
            Console.Clear();
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("            BRANCH TERMINATION");
            Console.WriteLine("------------------------------------------");
            Console.Write("Enter Branch ID to delete: ");
            string id = Console.ReadLine();

            for (int i = 0; i < branches.Count; i++)
            {
                if (branches[i].StartsWith(id + " |")) 
                {
                    Console.WriteLine("\n------------------------------------------");
                    Console.WriteLine("Branch deleted successfully!");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Branch not found.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
