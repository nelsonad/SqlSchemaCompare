using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public partial class Table : SchemaObject
    {
        public Table() : 
            this(String.Empty) 
        { }

        public Table(string tableName)
            : base(tableName, SchemaObjectTypeStrings.UserTable)
        {
            //Initialize lists.
            Objects = new List<TableObjectBase>();
        }

        [XmlElement("Column", typeof(TableColumn)),
         XmlElement("PrimaryKey", typeof(PrimaryKeyConstraint)),
         XmlElement("ForeignKey", typeof(ForeignKeyConstraint)),
         XmlElement("DefaultConstraint", typeof(DefaultConstraint)),
         XmlElement("UniqueConstraint", typeof(UniqueConstraint)),
         XmlElement("CheckConstraint", typeof(CheckConstraint)),
         XmlElement("Trigger", typeof(Trigger)),
         XmlElement("Index", typeof(TableIndex))]
        public List<TableObjectBase> Objects { get; set; }
    }
}
