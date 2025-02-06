using System;
using System.Collections.Generic;
using BSBank.BusinessLogicLayer.BALContracts;
using BSBank.Configuration;
using BSBank.DataAccessLayer;
using BSBank.DataAccessLayer.DALContracts;
using BSBank.Entities;
using BSBank.Exceptions;



namespace BSBank.BusinessLogicLayer
{
    public class CustomersBusinessLogicLayer : ICustomersBusinessLogicLayer
    {
        #region Private Fields
        private ICustomersDataAccessLayer _customersDataAccessLayer;
        #endregion

        #region Constructor
        public CustomersBusinessLogicLayer()
        {
            _customersDataAccessLayer = new CustomersDataAccessLayer();
        }
        #endregion

        #region Properties
        private ICustomersDataAccessLayer CustomersDataAccessLayer
        {
            set => _customersDataAccessLayer = value;
            get => _customersDataAccessLayer;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return all existing customers
        /// </summary>
        /// <returns>List of customers</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                // Invoke DAL
                return CustomersDataAccessLayer.GetCustomers();
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

        /// <summary>
        /// Returns a set of customers that satisfy the condition
        /// </summary>
        /// <param name="condition">Lambda expression that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> condition)
        {
            try
            {
                return CustomersDataAccessLayer.GetCustomersByCondition(condition);
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

        /// <summary>
        /// Add a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer object to add</param>
        /// <returns>Returns true, indicates that the customer is added sucsessfully</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                // Get all existing customers
                List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();
                long maxCustomerNo = 0;
                foreach (var item in allCustomers)
                {
                    if(item.CustomerCode > maxCustomerNo)
                    {
                        maxCustomerNo = item.CustomerCode;
                    }
                }

                // Generate a new customer code
                if(allCustomers.Count >= 1)
                {
                    customer.CustomerCode = maxCustomerNo + 1;
                } 
                else
                {
                    customer.CustomerCode = Settings.BaseCustomerNo + 1;
                }

                return CustomersDataAccessLayer.AddCustomer(customer);
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

        /// <summary>
        /// Update the existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update</param>
        /// <returns>Returns true, indicates that the customer is updated successfully</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                return CustomersDataAccessLayer.UpdateCustomer(customer);
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

        /// <summary>
        /// Delete the customer from the existing customers list
        /// </summary>
        /// <param name="customerID">Customer ID to delete</param>
        /// <returns>Returns true, indicates that customer is deleted successfully</returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                return CustomersDataAccessLayer.DeleteCustomer(customerID); 
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
        #endregion
    }
}
