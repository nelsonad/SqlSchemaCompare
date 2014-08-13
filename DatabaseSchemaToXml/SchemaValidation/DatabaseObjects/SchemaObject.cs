using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public abstract class SchemaObject
    {
        public SchemaObject() : 
            this(String.Empty, String.Empty) 
        { }

        public SchemaObject(string name, string type)
        {
            _type = type;
            this.Name = name;
        }

        private readonly string _type;

        [XmlAttribute]
        public String Name { get; set; }

        [XmlIgnore]
        public string Type
        {
            get
            {
                return _type;
            }
        }
    }
}
