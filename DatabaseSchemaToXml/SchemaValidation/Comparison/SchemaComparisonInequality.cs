using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaToXml
{
    public class SchemaComparisonInequality
    {
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public SchemaComparisonInequalityTypes InequalityType { get; set; }
    }
}
