using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHelathTestApi
{
    public class ContactEntityBuilder : BaseEntityBuilder<ContactEntity>
    {
        public override ContactEntity BuildEntity(MySqlDataReader reader)
        {
            ContactEntity contactDetail = new ContactEntity();
            try
            {
                contactDetail.Id = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]);

                contactDetail.FirstName = (reader["FirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FirstName"]);

                contactDetail.LastName = (reader["LastName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastName"]);

                contactDetail.Email = (reader["Email"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Email"]);

                contactDetail.PhoneNumber = (reader["PhoneNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PhoneNumber"]);

                contactDetail.Status = (reader["Status"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Status"]);

                return contactDetail;
            }
            catch (Exception ex)
            {
                return contactDetail;
            }
        }
    }
}
