using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public class TableIndex : TableObjectBase
    {
        public TableIndex() :
            this(String.Empty) 
        { }

        public TableIndex(string name)
            : base(name, SchemaObjectTypeStrings.TableIndex)
        { }
    }
}
