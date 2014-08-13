using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaToXml
{
    public class SchemaComparisonResult
    {
        public SchemaComparisonResult()
        {
            this.Inequalities = new List<SchemaComparisonInequality>();
        }

        public bool Equal
        {
            get
            {
                return this.Inequalities.Count == 0;
            }
        }

        public List<SchemaComparisonInequality> Inequalities { get; set; }

        internal void Merge(SchemaComparisonResult mergeResult)
        {
            this.Inequalities.AddRange(mergeResult.Inequalities);
        }
    }
}
