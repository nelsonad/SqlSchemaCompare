using DatabaseSchemaToXml.Classes.Discovery;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    [XmlRoot("Database")]
    [XmlInclude(typeof(Table)),
     XmlInclude(typeof(ForeignKeyConstraint)),
     XmlInclude(typeof(PrimaryKeyConstraint)),
     XmlInclude(typeof(ScalarValuedFunction)),
     XmlInclude(typeof(SchemaObject)),
     XmlInclude(typeof(StoredProcedure)),
     XmlInclude(typeof(TableValuedFunction))]
    public class Database
    {
        public Database() : 
            this(String.Empty) 
        { }

        public Database(string name)
        {
            this.Name = name;
            this.Tables = new List<Table>();
            this.Functions = new List<SqlFunctionBase>();
            this.StoredProcedures = new List<StoredProcedure>();
        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement("Table")]
        public List<Table> Tables { get; set; }

        [XmlElement("StoredProcedure")]
        public List<StoredProcedure> StoredProcedures { get; set; }

        [XmlElement("ScalarValuedFunction", typeof(ScalarValuedFunction)),
         XmlElement("TableValuedFunction", typeof(TableValuedFunction))]
        public List<SqlFunctionBase> Functions { get; set; }
    }
}
