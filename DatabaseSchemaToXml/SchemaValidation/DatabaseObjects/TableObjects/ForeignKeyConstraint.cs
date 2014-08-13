using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseSchemaToXml
{
    public class ForeignKeyConstraint : TableObjectBase
    {
        public ForeignKeyConstraint() : 
            this(String.Empty) 
        { }

        public ForeignKeyConstraint(string name)
            : base(name, SchemaObjectTypeStrings.ForeignKeyConstraint)
        { }
    }
}
