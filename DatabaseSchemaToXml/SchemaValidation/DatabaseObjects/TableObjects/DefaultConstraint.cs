using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseSchemaToXml
{
    public class DefaultConstraint : TableObjectBase
    {
        public DefaultConstraint() : 
            this(String.Empty) 
        { }

        public DefaultConstraint(string name)
            : base(name, SchemaObjectTypeStrings.DefaultConstraint)
        { }
    }
}
