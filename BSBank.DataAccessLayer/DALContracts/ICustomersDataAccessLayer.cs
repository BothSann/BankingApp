using System;
using BSBank.Entities;
using System.Collections.Generic;


namespace BSBank.DataAccessLayer.DALContracts
{
    /// <summary>
    /// Interface that represents the data access layer for customers
    /// </summary>
    public interface ICustomersDataAccessLayer
    {
        /// <summary>
        /// Return all existing customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Returns a set of customers that satisfy the condition
        /// </summary>
        /// <param name="condition">Lambda expression that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> condition);

        /// <summary>
        /// Add a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer object to add</param>
        /// <returns>Returns true, indicates that the customer is added sucsessfully</returns>
        Guid AddCustomer(Customer customer);

        /// <summary>
        /// Update the existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update</param>
        /// <returns>Returns true, indicates that the customer is updated successfully</returns>
        bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Delete the customer from the existing customers list
        /// </summary>
        /// <param name="customerID">Customer ID to delete</param>
        /// <returns>Returns true, indicates that customer is deleted successfully</returns>
        bool DeleteCustomer(Guid customerID);
    }
}
