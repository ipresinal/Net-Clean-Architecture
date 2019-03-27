using System;
using System.Collections.Generic;
using System.Text;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.Static.Data.Repositories;

namespace ConsoleApp
{
    public class Printer : IPrinter
    {
        

        #region Comments

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

        #endregion

        #region Repository area

        ICustomerService _customerService;

        #endregion

        public Printer(ICustomerService customerService)
        {
            _customerService = customerService;
            //Move to Infrastructure Layer later
            InitData();

            
        }

        #region UI

        public void StartUI()
        {
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
                        var customers = _customerService.GetAllCustomers();
                        ListCustomers(customers);
                        break;
                    case 2:
                        var firstName = AsQuestion("Firstname: ");
                        var lastName = AsQuestion("Lastname: ");
                        var address = AsQuestion("Address: ");
                        var customer = _customerService.NewCustomer(firstName, lastName, address);
                        _customerService.CreateCustomer(customer);
                        break;
                    case 3:
                        var idForDelete = PrintFindCustomerId();
                        _customerService.DeleteCustomer(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindCustomerId();
                        var customerToEdit = _customerService.FindCustomerById(idForEdit);
                        Console.WriteLine($"Updating {customerToEdit.FirstName}");
                        var newFirstName = AsQuestion("Firstname: ");
                        var newLastName = AsQuestion("Lastname: ");
                        var newAddress = AsQuestion("Address: ");
                        _customerService.UpdateCustomer(new Customer
                        {
                           Id = customerToEdit.Id,
                           FirstName = newFirstName,
                           LastName = newLastName,
                           Address = newAddress
                        });
                        //EditCustomer();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);

                
            }

            Console.WriteLine("Bye bye!");

            Console.ReadLine();

        }

        /// <summary>
        /// Shows the menu
        /// </summary>
        /// <param name="menuItems">Menu items</param>
        /// <returns>Menu choice as int</returns>
        int ShowMenu(string[] menuItems)
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

        int PrintFindCustomerId()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        string AsQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        void ListCustomers(List<Customer> customers)
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

        #endregion

        

        #region Infrastructure layer / Initializacion Layer

        void InitData()
        {
            var cust1 = new Customer()
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            };
            _customerService.CreateCustomer(cust1);

            var cust2 = new Customer()
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            };
            _customerService.CreateCustomer(cust2);
        }

        #endregion



        
    }
}
