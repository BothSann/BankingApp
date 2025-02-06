using System;
using System.Collections.Generic;
using BSBank.Entities;
using BSBank.Exceptions;
using BSBank.DataAccessLayer.DALContracts;

namespace BSBank.DataAccessLayer
{
    /// <summary>
    /// Represents the data access layer for bank customers
    /// </summary>
    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        #region Private Fields
        private static List<Customer> _customers;
        #endregion

        #region Constructor
        static CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Private Properties
        /// <summary>
        /// Represents source customers collection
        /// </summary>
        private static List<Customer> Customers
        {
            set => _customers = value;
            get => _customers;
        }
        #endregion

        #region Public Methods
        /// <summary>
        ///  Return all existing customers
        /// </summary>
        /// <returns>Customers List</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                // Create new customers list
                List<Customer> customersList = new List<Customer>();

                // Copy all customers from source collection into newCustomers list
                Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<Customer> GetCustomersByCondition(Predicate<Customer> condition)
        {
            try
            {
                // Create new customers list
                List<Customer> customersList = new List<Customer>();

                // Filer the collection 
                List<Customer> fitleredCustomers = Customers.FindAll(condition);

                // Copy all customers from source collection into newCustomers list
                fitleredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));

                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Guid AddCustomer(Customer customer)
        {
            try
            {
                // Generate new Guid
                customer.CustomerID = Guid.NewGuid();

                // Add customer to the collection
                Customers.Add(customer);

                return customer.CustomerID;
            } 
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                // Find the customer in the collection
                Customer existingCustomer = Customers.Find(item => item.CustomerID.Equals(customer.CustomerID));

                // Update all details of custome
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;

                    return true; // Customer updated successfully
                }
                else
                {
                    return false; // Customer not found
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                // Delete customer by customerID
                if (Customers.RemoveAll(item => item.CustomerID.Equals(customerID)) > 0)
                {
                    return true; // One or more customers deleted
                }
                else
                {
                    return false; // No customer is deleted

                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch
            {
                throw;
            }  
        }
        #endregion
    }
}
