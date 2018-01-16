using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using P3Net.Data.Common;

namespace P3Net.Data.Sql
{
    /// <summary>Provides a <see cref="ConnectionManager"/> implementation for SQL Server.</summary>
    public class SqlConnectionManager : DbProviderFactoryConnectionManager
    {
        #region Construction
        
        /// <summary>Initializes an instance of the <see cref="SqlConnectionManager"/> class.</summary>
        /// <param name="connectionString">The connection string to use.</param>
        public SqlConnectionManager (string connectionString) : base(SqlClientFactory.Instance, connectionString)
        {
        }
        #endregion

        /// <summary>Gets the schema information from the database.</summary>
        /// <returns>The schema information.</returns>
        protected override SchemaInformation LoadSchema ()
        {
            SchemaInformation schema = base.LoadSchema();

            //For some reason SQL does not return a properly formatted parameter name so fix it now
            schema.ParameterFormat = "@{0}";

            return schema;
        }
    }
}
