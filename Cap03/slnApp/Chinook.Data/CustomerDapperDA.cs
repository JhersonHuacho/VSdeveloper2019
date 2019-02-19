using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Chinook.Data
{
    public class CustomerDapperDA : BaseConnection
    {
        public int InsertCustomer(Customer entity)
        {
            var result = 0;
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>("usp_InsertCustomer"
                                       , new { //pCustomerId = entity.CustomerId,
                                               pFirstName = entity.FirstName,
                                               pLastName = entity.LastName,
                                               pCompany = entity.Company,
                                               pAddress = entity.Address,
                                               pCity = entity.City,
                                               pState = entity.State,
                                               pCountry = entity.Country,
                                               pPostalCode = entity.PostalCode,
                                               pPhone = entity.Phone,
                                               pFax = entity.Fax,
                                               pEmail = entity.Email,
                                               pSupportRepId = entity.SupportRepId
                                       }
                                       , commandType : CommandType.StoredProcedure).Single();
            }
            return result;
        }
        public bool UpdateCustomer(Customer entity)
        {
            var result = false;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Query("usp_UpdateCustomer",
                         new {  pCustomerId = entity.CustomerId,
                                pFirstName = entity.FirstName,
                                pLastName = entity.LastName
                         }
                         , commandType: CommandType.StoredProcedure);
                result = true;
            }

            return result;
        }
    }
}
