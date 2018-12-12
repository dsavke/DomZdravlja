using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.Helpers
{
    public static class DataReaderToDataSource
    {
        public static DataTable readToDataTable(SqlDataReader dr, PropertyInfo[] propertys)
        {
            DataTable podaci = new DataTable("podaci");

            foreach (PropertyInfo property in propertys)
            {
                podaci.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }
            if ( dr!= null)
            {
                podaci.Load(dr);
                dr.Close();
            }
            return podaci;
        }
    }
}
