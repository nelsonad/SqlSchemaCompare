﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaToXml
{
    public abstract class TableObjectBase : SchemaObject
    {
        public TableObjectBase(string name, string type) :
            base(name, type) 
        { }
    }
}
