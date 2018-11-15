using System;
using System.Collections.Generic;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.Static.Data.Repositories;

namespace ConsoleApp
{
    public class Printer
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

        ICustomerRepository customerRepository;

        #endregion

        public Printer()
        {
            customerRepository = new CustomerRepository();
            //Move to Infrastructure Layer later
            InitData();

            //Main UI
            StartUI();
        }

        #region UI

        void StartUI()
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
                        var customers = GetAllCustomers();
                        ListCustomers(customers);
                        break;
                    case 2:
                        var firstName = AsQuestion("Firstname: ");
                        var lastName = AsQuestion("Lastname: ");
                        var address = AsQuestion("Address: ");
                        var customer = CreateCustomer(firstName, lastName, address);
                        SaveCustomer(customer);
                        break;
                    case 3:
                        var idForDelete = PrintFindCustomerId();
                        DeleteCustomer(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindCustomerId();
                        var customerToEdit = FindCustomerById(idForEdit);
                        Console.WriteLine($"Updating {customerToEdit.FirstName}");
                        var newFirstName = AsQuestion("Firstname: ");
                        var newLastName = AsQuestion("Lastname: ");
                        var newAddress = AsQuestion("Address: ");
                        UpdateCustomer(idForEdit, newFirstName, newLastName, newAddress);
                        //EditCustomer();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);

                Console.WriteLine("Bye bye!");

                Console.ReadLine();
            }


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

        #endregion

        #region Please move to Application service

        void UpdateCustomer(int id, string newFirstName, string newLastName, string newAddress)
        {
            var customer = FindCustomerById(id);
            customer.FirstName = newFirstName;
            customer.LastName = newLastName;
            customer.Address = newAddress;

            //Save with repository  !!
            customerRepository.Update(customer);
        }

        Customer FindCustomerById(int id)
        {
            return customerRepository.ReadById(id);
        }

        List<Customer> GetAllCustomers()
        {
            return customerRepository.ReadAll();
        }

        void DeleteCustomer(int id)
        {
            customerRepository.Delete(id);
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

        
        //Application Service
        Customer CreateCustomer(string firstName, string lastName, string address)
        {
            var cust = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };
            return cust;
        }

        //Application Service
        Customer SaveCustomer(Customer cust)
        {
            //Save in Data - Application
            return customerRepository.Create(cust);
        }

        //void EditCustomer()
        //{


        //    var id = PrintFindCustomerId();
        //    var customer = FindCustomerById(id);

        //    Console.WriteLine("FirstName: ");
        //    customer.FirstName = Console.ReadLine();
        //    Console.WriteLine("LastName: ");
        //    customer.LastName = Console.ReadLine();
        //    Console.WriteLine("Address: ");
        //    customer.Address = Console.ReadLine();

            

        //}        

        //Application Service
              

        #endregion

        #region Infrastructure kayer / Initializacion Layer

        void InitData()
        {
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
        }

        #endregion



        
    }
}
