using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseSchemaToXml
{
    public class CheckConstraint : TableObjectBase
    {
        public CheckConstraint() : 
            this(String.Empty) 
        { }

        public CheckConstraint(string name)
            : base(name, SchemaObjectTypeStrings.CheckConstraint)
        { }
    }
}
