using System;
using System.Collections.Generic;
using BSBank.Entities;
using BSBank.Exceptions;
using BSBank.BusinessLogicLayer;
using BSBank.BusinessLogicLayer.BALContracts;
using System.Linq;

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

        internal static void DeleteCustomer()
        {
            try
            {
                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLayer = new CustomersBusinessLogicLayer();
                if (customersBusinessLayer.GetCustomers().Count <= 0)
                {
                    Console.WriteLine("No Customers Exist");
                    return;
                }
                Console.WriteLine("======== DELETE CUSTOMER ========");
                long customerCodeToDelete;
                while (!long.TryParse(Console.ReadLine(), out customerCodeToDelete))
                {
                }
                var existingCustomer = customersBusinessLayer.GetCustomersByCondition(item => item.CustomerCode.Equals(customerCodeToDelete)).FirstOrDefault();
                if (existingCustomer.Equals(null))
                {
                    Console.WriteLine("Ivalid Customer Code!");
                    return;
                }
                bool isDeleted = customersBusinessLayer.DeleteCustomer(existingCustomer.CustomerID);
                if (isDeleted)
                {
                    Console.WriteLine("Customer Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Customer not deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void UpdateCustomer ()
        {
            try
            {
                // Create BL object 
                ICustomersBusinessLogicLayer customersBusinessLayer = new CustomersBusinessLogicLayer();

                if(customersBusinessLayer.GetCustomers().Count <= 0)
                {
                    Console.WriteLine("No Customers Exist");
                    return;
                }

                Console.WriteLine("======== UPDATE CUSTOMER ========");
                long customerCodeToEdit;
                while (!long.TryParse(Console.ReadLine(), out customerCodeToEdit))
                {

                }
                var existingCustomer = customersBusinessLayer.GetCustomersByCondition(item => item.CustomerCode.Equals(customerCodeToEdit)).FirstOrDefault();
                if (existingCustomer.Equals(null))
                {
                    Console.WriteLine("Ivalid Customer Code!");
                    return;
                }
                Console.WriteLine("NEW CUSTOMER DETAILS:");
                Console.Write("Enter Customer Name: ");
                existingCustomer.CustomerName = Console.ReadLine();
                Console.Write("Enter Address: ");
                existingCustomer.Address = Console.ReadLine();
                Console.Write("Enter Landmark: ");
                existingCustomer.Landmark = Console.ReadLine();
                Console.Write("Enter City: ");
                existingCustomer.City = Console.ReadLine();
                Console.Write("Enter Country: ");
                existingCustomer.Country = Console.ReadLine();
                Console.Write("Enter Mobile: ");
                existingCustomer.Mobile = Console.ReadLine();

                bool isUpdated = customersBusinessLayer.UpdateCustomer(existingCustomer);
                if (isUpdated)
                {
                    Console.WriteLine("Customer Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Customer not updated");
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
