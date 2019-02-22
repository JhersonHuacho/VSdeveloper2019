using System;
using Chinook.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class CustomerDapperDATest
    {
        [TestMethod]
        public void InsertCustomerWithOutput()
        {
            var da = new CustomerDapperDA();
            var nuevoCustomer = da.InsertCustomer(new Customer()
            {               
                FirstName = "Francisco",
                LastName = "Huacho",
                Company = "xx",
                Address = "xx",
                City = "lima",
                State = "20",
                Country = "perú",
                PostalCode = "200",
                Phone = "9999",
                Fax = "099",
                Email = "francisco@gmail.com",
                SupportRepId = 2
            });

            Assert.IsTrue(nuevoCustomer > 0);
        }

        [TestMethod]
        public void UpdatetCustomerTest()
        {
            var da = new CustomerDapperDA();
            var updateCustome = da.UpdateCustomer(new Customer()
            {
                CustomerId = 1,
                FirstName = "Jherson",
                LastName = "avalos"
            });

            Assert.IsTrue(updateCustome == true);

        }
    }
}
