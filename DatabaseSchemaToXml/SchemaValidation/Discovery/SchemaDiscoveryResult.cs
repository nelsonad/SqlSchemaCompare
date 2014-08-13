using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaToXml.Classes.Discovery
{
    internal class SchemaDiscoveryResult
    {
        public string DatabaseName { get; set; }
        public List<DbObject> Objects { get; set; }
        public List<DbColumn> Columns { get; set; }
        public List<DbIndex> Indexes { get; set; }
    }
}
