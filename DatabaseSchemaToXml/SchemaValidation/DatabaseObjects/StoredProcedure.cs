using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseSchemaToXml
{
    public partial class StoredProcedure : SchemaObject
    {
        public StoredProcedure() : 
            this(String.Empty) 
        { }

        public StoredProcedure(string name)
            : base(name, SchemaObjectTypeStrings.SqlStoredProcedure)
        { }
    }
}
