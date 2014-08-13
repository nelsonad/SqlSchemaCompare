using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public class Trigger : TableObjectBase
    {
        public Trigger() : 
            this(String.Empty) 
        { }

        public Trigger(string name)
            : base(name, SchemaObjectTypeStrings.SqlTrigger)
        { }
    }
}
