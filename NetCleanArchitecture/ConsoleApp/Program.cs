using System;
using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.Static.Data.Repositories;

namespace ConsoleApp
{
    
    


    // -- UI --
    //Console. WriteLine
    //Console.ReadLine

    //-- Infrastructure --
    //EF - Static List - Text File

    // --- Test ---
    // Unit test for Core
    //

    //--- CORE ---
    //Customer - Entity - Core.Entity
    //Domain Service - Repository / UOW - Core  --> Talks to Data Operations
    //Application Service - Service - Core --> Talks to UI Operations


    class Program
    {
        private static ICustomerRepository customerRepository;

        static void Main(string[] args)
        {

            customerRepository = new CustomerRepository();

            var cust1 = new Customer()
            {               
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            };
            customerRepository.Create(cust1);

            var cust2 = new Customer()
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            };
            customerRepository.Create(cust2);

            string[] menuItems = {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };

            //Show Menu
            //Wait for Selection
            // - Show selection or
            // - Warning and go back to menu

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomers();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        EditCustomer();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        private static void EditCustomer()
        {
            var customer = FindCustomerById();
            Console.WriteLine("FirstName: ");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("LastName: ");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Address: ");
            customer.Address = Console.ReadLine();

        }

        private static Customer FindCustomerById()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return customerRepository.ReadById(id);

        }

        private static void DeleteCustomer()
        {

            var customerFound = FindCustomerById();
            if (customerFound != null)
            {
                customerRepository.Delete(customerFound.Id);
            }
        }

        private static void AddCustomers()
        {
            Console.WriteLine("Firstname: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Lastname: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            var address = Console.ReadLine();

            var cust = new Customer()
            {                
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };

            customerRepository.Create(cust);
        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.FirstName} " +
                                $"{customer.LastName} " +
                                $"Adress: {customer.Address}");
            }
            Console.WriteLine("\n");

        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
    }
}

