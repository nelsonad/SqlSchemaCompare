using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public class UniqueConstraint : TableObjectBase
    {
        public UniqueConstraint() : 
            this(String.Empty) 
        { }

        public UniqueConstraint(string name)
            : base(name, SchemaObjectTypeStrings.UniqueConstraint)
        { }
    }
}
