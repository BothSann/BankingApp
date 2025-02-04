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
        private List<Customer> _customers;
        #endregion

        #region Constructor
        public CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Private Properties
        /// <summary>
        /// Represents source customers collection
        /// </summary>
        private List<Customer> Customers
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
            List<Customer> customersList = new List<Customer>();

            Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
            return customersList;
        }
        #endregion
    }
}
