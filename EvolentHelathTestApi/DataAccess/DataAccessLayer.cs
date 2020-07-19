using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHelathTestApi
{
    public class DataAccessLayer
    {

        public string CommandTxt
        {
            get; set;
        }

        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get
            {
                if (connection != null)
                {
                    return connection;
                }
                else
                {
                    connection = new MySqlConnection(Startup.DbConnectionString);
                    return connection;
                }

            }
        }
        public void OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {

                Connection.Open();
            }
            else
            {
                Connection.Close();
                Connection.Open();
            }
        }



        #region Store Procedures Constants
        public const string SP_Contacts_I_contact = "SP_Contacts_I_contact";
        public const string SP_Contacts_U_contact = "SP_Contacts_U_contact";
        public const string SP_Contacts_G_ALL_contact = "SP_Contacts_G_ALL_contact";
        public const string SP_Contacts_G_ById_contact = "SP_Contacts_G_ById_contact";
        public const string SP_Contacts_D_ById_contact = "SP_Contacts_D_ById_contact";
        public const string SP_Contacts_G_Email_count = "SP_Contacts_G_Email_count";


        #endregion
    }



}
