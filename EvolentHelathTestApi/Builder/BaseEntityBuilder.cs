using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHelathTestApi
{
    public abstract class BaseEntityBuilder<T>
    {
        public abstract T BuildEntity(SqlDataReader record);

        public List<T> BuildEntities(SqlDataReader reader)
        {
            List<T> collection = new List<T>();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            collection.Add(BuildEntity(reader));
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                reader.Close();
                collection = null;
            }
            return collection;

        }


    }
}
