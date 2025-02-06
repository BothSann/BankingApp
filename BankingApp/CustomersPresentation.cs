using System;
using System.Collections.Generic;
using BSBank.Entities;
using BSBank.Exceptions;
using BSBank.BusinessLogicLayer;
using BSBank.BusinessLogicLayer.BALContracts;

namespace BankingApp
{
    static class CustomersPresentation
    {
        internal static void AddCustomer()
        {
            // Create an object of Customer 
            Customer customer = new Customer();
            try
            {
                Console.Clear();
                // Read all details from the user
                Console.WriteLine("\n======== ADD CUSTOMER ========");
                Console.Write("Enter Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Enter Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("Enter Landmark: ");
                customer.Landmark = Console.ReadLine();
                Console.Write("Enter City: ");
                customer.City = Console.ReadLine();
                Console.Write("Enter Country: ");
                customer.Country = Console.ReadLine();
                Console.Write("Enter Mobile: ");
                customer.Mobile = Console.ReadLine();
                Console.Clear();

                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLayer = new CustomersBusinessLogicLayer();
                Guid newGuid = customersBusinessLayer.AddCustomer(customer);

                List<Customer> matchingCustomers = customersBusinessLayer.GetCustomersByCondition(item => item.CustomerID.Equals(newGuid));
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("\n\nCustomer added successfully");
                    Console.WriteLine("New Customer Code: " + matchingCustomers[0].CustomerCode);
                }
                else
                {
                    Console.WriteLine("Customer not added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void ViewCustomers()
        {
            try
            {
                Console.Clear();
                // Create Bl object   
                ICustomersBusinessLogicLayer customersBusinessLayer = new CustomersBusinessLogicLayer();
                List<Customer> allCustomers = customersBusinessLayer.GetCustomers();
                Console.WriteLine("======== ALL CUSTOMERS ========\n");   

                // Read all customers
                foreach (var item in allCustomers)
                {
                    Console.WriteLine("Customer Code: " + item.CustomerCode);
                    Console.WriteLine("Customer Name: " + item.CustomerName);
                    Console.WriteLine("Customer Address: " + item.Address);
                    Console.WriteLine("Customer Landmark: " + item.Landmark);
                    Console.WriteLine("Customer City: " + item.City);
                    Console.WriteLine("Customer Country: " + item.Country);
                    Console.WriteLine("Customer Mobile: " + item.Mobile);
                    Console.WriteLine();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
