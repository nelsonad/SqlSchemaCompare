using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseSchemaToXml
{
    public partial class ScalarValuedFunction : SqlFunctionBase
    {
        public ScalarValuedFunction() : 
            this(String.Empty) 
        { }

        public ScalarValuedFunction(string name)
            : base(name, SchemaObjectTypeStrings.SqlScalarFunction)
        { }
    }
}
