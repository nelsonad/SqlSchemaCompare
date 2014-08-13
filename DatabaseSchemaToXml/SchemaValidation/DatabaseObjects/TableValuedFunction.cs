using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseSchemaToXml
{
    public partial class TableValuedFunction : SqlFunctionBase
    {
        public TableValuedFunction() : 
            this(String.Empty) 
        { }

        public TableValuedFunction(string name)
            : base(name, SchemaObjectTypeStrings.SqlTableValuedFunction)
        { }
    }
}
