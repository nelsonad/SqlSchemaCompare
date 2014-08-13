using DatabaseSchemaToXml.Classes.Discovery;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public static class DatabaseSchemaService
    {
        #region SQL Schema Queries
        private const string SqlObjectsQuery = @"SELECT 
       c.name 'Name', 
       c.type 'Type',
	   p.name 'ParentName',
	   p.type 'ParentType'
FROM   sys.objects c
LEFT OUTER JOIN sys.objects p on p.object_id = c.parent_object_id
ORDER BY c.type, c.name";

        private const string SqlColumnsQuery = @"SELECT 
       so.name 'TableName', 
       sc.name 'ColumnName'
FROM   sys.objects  so , 
       sys.columns  sc 
WHERE  so.object_id = sc.object_id 
and    so.type = 'U' 
ORDER BY so.type, so.name, sc.name";

        private const string SqlIndexesQuery = @"SELECT 
       so.name as 'TableName',
       si.name as 'IndexName' 
FROM   sys.indexes si 
JOIN   sys.objects so on si.object_id = so.object_id
WHERE  si.type = 2 
and    si.is_unique = 0 
and    si.is_primary_key = 0
and    so.type = 'U'
ORDER BY so.name, si.name";
        #endregion

        #region Method - Generate
        /// <summary>
        /// Queries the target database specified by the connection string for schema information and converts it into a serializable DatabaseSchema object.
        /// </summary>
        public static Database Generate(string connectionString)
        {
            SchemaDiscoveryResult results = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                results = GetSchemaInformation(connection);

                connection.Close();
            }

            return ProcessResults(results);
        }
        #endregion

        #region Method - GetSchemaInformation
        /// <summary>
        /// Queries the target database specified by the SqlConnection for schema information.
        /// </summary>
        private static SchemaDiscoveryResult GetSchemaInformation(SqlConnection connection)
        {
            using (DataContext context = new DataContext(connection))
            {
                return new SchemaDiscoveryResult
                {
                    DatabaseName = connection.Database,
                    Objects = context.ExecuteQuery<DbObject>(SqlObjectsQuery).ToList(),
                    Columns = context.ExecuteQuery<DbColumn>(SqlColumnsQuery).ToList(),
                    Indexes = context.ExecuteQuery<DbIndex>(SqlIndexesQuery).ToList()
                };
            }
        }
        #endregion

        #region Method - ProcessResults
        /// <summary>
        /// Converts information from sql schema discovery queries and turns it into serializable DatabaseSchema objects.
        /// </summary>
        private static Database ProcessResults(SchemaDiscoveryResult results)
        {
            if (results == null)
            {
                return new Database();
            }

            Database databaseSchema = new Database(results.DatabaseName);

            //Tables
            foreach (var tableResult in results.Objects.Where(x => x.Type == SchemaObjectTypeStrings.UserTable))
            {
                var tableSchema = new Table(tableResult.Name);

                //columns
                tableSchema.Objects.AddRange(
                    results.Columns.Where(x => x.TableName == tableResult.Name).Select(x => new TableColumn(x.ColumnName))        
                );

                var tableObjects = results.Objects.Where(x => x.ParentName == tableResult.Name).ToList();
                var tableIndexes = results.Indexes.Where(x => x.TableName == tableResult.Name).ToList();

                //primary keys
                tableSchema.Objects.AddRange(
                    tableObjects.Where(x => x.Type == SchemaObjectTypeStrings.PrimaryKeyConstraint).Select(x => new PrimaryKeyConstraint(x.Name))
                );

                //foreign keys
                tableSchema.Objects.AddRange(
                    tableObjects.Where(x => x.Type == SchemaObjectTypeStrings.ForeignKeyConstraint).Select(x => new ForeignKeyConstraint(x.Name))
                );

                //default contstraints
                tableSchema.Objects.AddRange(
                    tableObjects.Where(x => x.Type == SchemaObjectTypeStrings.DefaultConstraint).Select(x => new DefaultConstraint(x.Name))
                );

                //unique contstraints
                tableSchema.Objects.AddRange(
                    tableObjects.Where(x => x.Type == SchemaObjectTypeStrings.UniqueConstraint).Select(x => new UniqueConstraint(x.Name))
                );

                //check constraints
                tableSchema.Objects.AddRange(
                    tableObjects.Where(x => x.Type == SchemaObjectTypeStrings.CheckConstraint).Select(x => new CheckConstraint(x.Name))
                );

                //triggers
                tableSchema.Objects.AddRange(
                    tableObjects.Where(x => x.Type == SchemaObjectTypeStrings.SqlTrigger).Select(x => new Trigger(x.Name))
                );

                //indexes
                tableSchema.Objects.AddRange(
                    tableIndexes.Select(x => new TableIndex(x.IndexName))
                );

                databaseSchema.Tables.Add(tableSchema);
            }

            //Stored Procedures
            databaseSchema.StoredProcedures.AddRange(
                results.Objects.Where(x => x.Type == SchemaObjectTypeStrings.SqlStoredProcedure).Select(x => new StoredProcedure(x.Name))
            );

            //Functions
            databaseSchema.Functions.AddRange(
                results.Objects.Where(x => x.Type == SchemaObjectTypeStrings.SqlScalarFunction).Select(x => new ScalarValuedFunction(x.Name))
            );
            databaseSchema.Functions.AddRange(
                results.Objects.Where(x => x.Type == SchemaObjectTypeStrings.SqlTableValuedFunction).Select(x => new TableValuedFunction(x.Name))
            );

            return databaseSchema;
        }
        #endregion
    }
}
