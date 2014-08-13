using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseSchemaToXml
{
    public class SchemaObjectTypeStrings
    {
        /// <summary>
        /// Type Code: "AF"
        /// </summary>
        public const string AggregateFunction = "AF";

        /// <summary>
        /// Type Code: "C "
        /// </summary>
        public const string CheckConstraint = "C ";

        /// <summary>
        /// Type Code: "D "
        /// </summary>
        public const string DefaultConstraint = "D ";

        /// <summary>
        /// Type Code: "F "
        /// </summary>
        public const string ForeignKeyConstraint = "F ";

        /// <summary>
        /// Type Code: "FN"
        /// </summary>
        public const string SqlScalarFunction = "FN";

        /// <summary>
        /// Type Code: "FS"
        /// </summary>
        public const string ClrScalarFunction = "FS";

        /// <summary>
        /// Type Code: "FT"
        /// </summary>
        public const string ClrTableValuedFunction = "FT";

        /// <summary>
        /// Type Code: "IF"
        /// </summary>
        public const string SqlInlineTableValuedFunction = "IF";

        /// <summary>
        /// Type Code: "IT"
        /// </summary>
        public const string InternalTable = "IT";

        /// <summary>
        /// Type Code: "P "
        /// </summary>
        public const string SqlStoredProcedure = "P ";

        /// <summary>
        /// Type Code: "PC"
        /// </summary>
        public const string ClrStoredProcedure = "PC";

        /// <summary>
        /// Type Code: "PG"
        /// </summary>
        public const string PlanGuide = "PG";

        /// <summary>
        /// Type Code: "PK"
        /// </summary>
        public const string PrimaryKeyConstraint = "PK";

        /// <summary>
        /// Type Code: "R "
        /// </summary>
        public const string Rule = "R ";

        /// <summary>
        /// Type Code: "RF"
        /// </summary>
        public const string ReplicationFilterProcedure = "RF";

        /// <summary>
        /// Type Code: "S "
        /// </summary>
        public const string SystemTable = "S ";

        /// <summary>
        /// Type Code: "SN"
        /// </summary>
        public const string Synonym = "SN";

        /// <summary>
        /// Type Code: "SO"
        /// </summary>
        public const string SequenceObject = "SO";

        /// <summary>
        /// Type Code: "SQ"
        /// </summary>
        public const string ServiceQueue = "SQ";

        /// <summary>
        /// Type Code: "TA"
        /// </summary>
        public const string ClrTrigger = "TA";

        /// <summary>
        /// Type Code: "TF"
        /// </summary>
        public const string SqlTableValuedFunction = "TF";

        /// <summary>
        /// Type Code: "TR"
        /// </summary>
        public const string SqlTrigger = "TR";

        /// <summary>
        /// Type Code: "TT"
        /// </summary>
        public const string TableType = "TT";

        /// <summary>
        /// Type Code: "U "
        /// </summary>
        public const string UserTable = "U ";

        /// <summary>
        /// Type Code: "UQ"
        /// </summary>
        public const string UniqueConstraint = "UQ";

        /// <summary>
        /// Type Code: "V "
        /// </summary>
        public const string View = "V ";

        /// <summary>
        /// Type Code: "X "
        /// </summary>
        public const string ExtendedStoredProcedure = "X ";

        /// <summary>
        /// Type Code: "_column", custom object type, sql columns do not have a type code. 
        /// </summary>
        public const string TableColumn = "_column";

        /// <summary>
        /// Type Code: "_index", custom object type, non-unique, non-clustered sql indexes do not have a type code. 
        /// </summary>
        public const string TableIndex = "_index";
    }
}
