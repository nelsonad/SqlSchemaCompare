using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public class PrimaryKeyConstraint : TableObjectBase
    {
        public PrimaryKeyConstraint() : 
            this(String.Empty) 
        { }

        public PrimaryKeyConstraint(string name)
            : base(name, SchemaObjectTypeStrings.PrimaryKeyConstraint)
        { }
    }
}
