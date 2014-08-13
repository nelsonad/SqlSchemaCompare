using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public class TableColumn : TableObjectBase
    {
        public TableColumn() : 
            this(String.Empty) 
        { }

        public TableColumn(string name)
            : base(name, SchemaObjectTypeStrings.TableColumn)
        { }
    }
}
