using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaToXml
{
    public static class SchemaComparer
    {
        public static SchemaComparisonResult Compare(this Database source, Database target, bool strict = false)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }

            SchemaComparisonResult result = new SchemaComparisonResult();

            result.Merge(CompareTables(source, target, strict));

            result.Merge(CompareFunctions(source, target, strict));

            result.Merge(CompareStoredProcedures(source, target, strict));

            return result;
        }

        private static SchemaComparisonResult CompareFunctions(Database source, Database target, bool strict)
        {
            SchemaComparisonResult result = new SchemaComparisonResult();

            var sourceObjectsMissingInTarget = source.Functions.Where(x => !target.Functions.Any(y => y.Name == x.Name && y.Type == x.Type));
            if (sourceObjectsMissingInTarget.Count() > 0)
            {
                result.Inequalities.AddRange(sourceObjectsMissingInTarget.Select(x => new SchemaComparisonInequality
                {
                    ObjectName = x.Name,
                    ObjectType = x.Type,
                    InequalityType = SchemaComparisonInequalityTypes.MissingInTarget
                }));
            }

            if (strict)
            {
                var targetObjectsMissingInSource = target.Functions.Where(x => !source.Functions.Any(y => y.Name == x.Name && y.Type == x.Type));
                if (targetObjectsMissingInSource.Count() > 0)
                {
                    result.Inequalities.AddRange(targetObjectsMissingInSource.Select(x => new SchemaComparisonInequality
                    {
                        ObjectName = x.Name,
                        ObjectType = x.Type,
                        InequalityType = SchemaComparisonInequalityTypes.MissingInSource
                    }));
                }
            }

            return result;
        }

        private static SchemaComparisonResult CompareStoredProcedures(Database source, Database target, bool strict)
        {
            SchemaComparisonResult result = new SchemaComparisonResult();

            var sourceObjectsMissingInTarget = source.StoredProcedures.Where(x => !target.StoredProcedures.Any(y => y.Name == x.Name && y.Type == x.Type));
            if (sourceObjectsMissingInTarget.Count() > 0)
            {
                result.Inequalities.AddRange(sourceObjectsMissingInTarget.Select(x => new SchemaComparisonInequality
                {
                    ObjectName = x.Name,
                    ObjectType = x.Type,
                    InequalityType = SchemaComparisonInequalityTypes.MissingInTarget
                }));
            }

            if (strict)
            {
                var targetObjectsMissingInSource = target.StoredProcedures.Where(x => !source.StoredProcedures.Any(y => y.Name == x.Name && y.Type == x.Type));
                if (targetObjectsMissingInSource.Count() > 0)
                {
                    result.Inequalities.AddRange(targetObjectsMissingInSource.Select(x => new SchemaComparisonInequality
                    {
                        ObjectName = x.Name,
                        ObjectType = x.Type,
                        InequalityType = SchemaComparisonInequalityTypes.MissingInSource
                    }));
                }
            }

            return result;
        }

        private static SchemaComparisonResult CompareTables(Database source, Database target, bool strict)
        {
            SchemaComparisonResult result = new SchemaComparisonResult();

            var sourceTablesMissingInTarget = source.Tables.Where(x => !target.Tables.Any(y => y.Name == x.Name));
            if (sourceTablesMissingInTarget.Count() > 0)
            {
                result.Inequalities.AddRange(sourceTablesMissingInTarget.Select(x => new SchemaComparisonInequality
                {
                    ObjectName = x.Name,
                    ObjectType = x.Type,
                    InequalityType = SchemaComparisonInequalityTypes.MissingInTarget
                }));
            }

            if (strict)
            {
                var targetTablesMissingInSource = source.Tables.Where(x => !target.Tables.Any(y => y.Name == x.Name));
                if (targetTablesMissingInSource.Count() > 0)
                {
                    result.Inequalities.AddRange(targetTablesMissingInSource.Select(x => new SchemaComparisonInequality
                    {
                        ObjectName = x.Name,
                        ObjectType = x.Type,
                        InequalityType = SchemaComparisonInequalityTypes.MissingInSource
                    }));
                }
            }

            var commonTables = source.Tables.Where(x => target.Tables.Exists(y => y.Name == x.Name));
            foreach (var table in commonTables)
            {
                var targetTable = target.Tables.FirstOrDefault(x => x.Name == table.Name);
                if (targetTable == null)
                {
                    continue; //Shouldnt be possible
                }
                result.Merge(CompareTable(table, targetTable, strict));
            }
            return result;
        }

        private static SchemaComparisonResult CompareTable(Table source, Table target, bool strict)
        {
            SchemaComparisonResult result = new SchemaComparisonResult();

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }

            var sourceObjectsMissingInTarget = source.Objects.Where(x => !target.Objects.Any(y => y.Name == x.Name && y.Type == x.Type));
            if (sourceObjectsMissingInTarget.Count() > 0)
            {
                result.Inequalities.AddRange(sourceObjectsMissingInTarget.Select(x => new SchemaComparisonInequality
                {
                    ObjectName = x.Name,
                    ObjectType = x.Type,
                    InequalityType = SchemaComparisonInequalityTypes.MissingInTarget
                }));
            }

            if (strict)
            {
                var targetObjectsMissingInSource = source.Objects.Where(x => !target.Objects.Any(y => y.Name == x.Name && y.Type == x.Type));
                if (targetObjectsMissingInSource.Count() > 0)
                {
                    result.Inequalities.AddRange(targetObjectsMissingInSource.Select(x => new SchemaComparisonInequality
                    {
                        ObjectName = x.Name,
                        ObjectType = x.Type,
                        InequalityType = SchemaComparisonInequalityTypes.MissingInSource
                    }));
                }
            }

            return result;
        }
    }
}
