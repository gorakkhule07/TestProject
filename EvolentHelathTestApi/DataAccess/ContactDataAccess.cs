using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHelathTestApi
{
    public class ContactDataAccess : DataAccessLayer, IContactDataAccess
    {

        public int SaveContact(ContactEntity contact)
        {
            int result = 0;
            try
            {

                CommandTxt = SP_Contacts_I_contact;
                SqlCommand dbCommand = new SqlCommand(CommandTxt, Connection);
                dbCommand.CommandType = CommandType.StoredProcedure;
                OpenConnection();
                dbCommand.Parameters.Clear();
                dbCommand.Parameters.AddWithValue("@iEmail", contact.Email);
                dbCommand.Parameters.AddWithValue("@iFirstName", contact.FirstName);
                dbCommand.Parameters.AddWithValue("@iLastName", contact.LastName);
                dbCommand.Parameters.AddWithValue("@iPhoneNumber", contact.PhoneNumber);
                dbCommand.Parameters.AddWithValue("@iStatus", contact.Status);
                result = dbCommand.ExecuteNonQuery();
                Connection.Close();
                return result;
            }
            catch (Exception ex)
            
            {
                Connection.Close();
                return result;

            }
        }

        public List<ContactEntity> GetAllContact()
        {
            List<ContactEntity> lstContactEntity = null;
            ContactEntityBuilder contactBuilder = new ContactEntityBuilder();
            try
            {

                CommandTxt = SP_Contacts_G_ALL_contact;
                OpenConnection();
                SqlCommand dbCommand = new SqlCommand(CommandTxt, Connection);
                dbCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dataReader = dbCommand.ExecuteReader())
                {
                    lstContactEntity = contactBuilder.BuildEntities(dataReader);
                }
                Connection.Close();
                return lstContactEntity;
            }
            catch (Exception ex)
            {
                return lstContactEntity;
            }

        }

        public ContactEntity GetContactById(int Id)
        {
            ContactEntity contactEntity = new ContactEntity();
            ContactEntityBuilder contactBuilder = new ContactEntityBuilder();
            try
            {

                CommandTxt = SP_Contacts_G_ById_contact;

                OpenConnection();
                SqlCommand dbCommand = new SqlCommand(CommandTxt, Connection);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.Parameters.AddWithValue("@iId", Id);
                using (SqlDataReader reader = dbCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            contactEntity = contactBuilder.BuildEntity(reader);
                        }
                    }
                }
                Connection.Close();
                return contactEntity;
            }
            catch (Exception ex)
            {
                return contactEntity;
            }
        }

        public int UpdateContact(ContactEntity contact)
        {
            int result = 0;
            try
            {

                CommandTxt = SP_Contacts_U_contact;
                OpenConnection();
                SqlCommand dbCommand = new SqlCommand(CommandTxt, Connection);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.Parameters.AddWithValue("@iId", contact.Id);
                dbCommand.Parameters.AddWithValue("@iEmail", contact.Email);
                dbCommand.Parameters.AddWithValue("@iFirstName", contact.FirstName);
                dbCommand.Parameters.AddWithValue("@iLastName", contact.LastName);
                dbCommand.Parameters.AddWithValue("@iPhoneNumber", contact.PhoneNumber);
                dbCommand.Parameters.AddWithValue("@iStatus", contact.Status);
                result = dbCommand.ExecuteNonQuery();
                Connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                Connection.Close();
                return result;

            }
        }

        public int DeleteContactByid(int Id)
        {
            int result = 0;
            try
            {

                CommandTxt = SP_Contacts_D_ById_contact;
                OpenConnection();
                SqlCommand dbCommand = new SqlCommand(CommandTxt, Connection);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.Parameters.AddWithValue("@iId", Id);
                result = dbCommand.ExecuteNonQuery();
                Connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                Connection.Close();
                return result;

            }
        }

        public int CheckDuplicateEmail(int Id, string Email)
        {
            int result = 0;
            try
            {
                CommandTxt = SP_Contacts_G_Email_count;
                SqlCommand dbCommand = new SqlCommand(CommandTxt, Connection);
                dbCommand.CommandType = CommandType.StoredProcedure;
                OpenConnection();
                dbCommand.Parameters.Clear();
                dbCommand.Parameters.AddWithValue("@iId", Id);
                dbCommand.Parameters.AddWithValue("@iEmail", Email);
                result = Convert.ToInt32(dbCommand.ExecuteScalar());
                Connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                Connection.Close();
                return result;

            }
        }
    }
}
