using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaToXml.Classes.Discovery
{
    internal class DbColumn
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
    }
}
