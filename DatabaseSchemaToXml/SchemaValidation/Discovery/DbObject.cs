using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaToXml.Classes.Discovery
{
    internal class DbObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }
    }
}
