SqlSchemaCompare
================

This project does simple sql schema comparisons based on schema object names and type.

Examples
================

Generate schema and save to xml file.

DatabaseSchemaService.Generate(connectionString).Serialize(filePath);



Deserialize schema from file.

Database schema = SchemaSerializer.Deserialize(filePath);



Compare schemas

Database schemaA = SchemaSerializer.Deserialize(filePath);

Database schemaB = DatabaseSchemaService.Generate(connectionString());

SchemaComparisonResult result = schemaA.Compare(schemaB);
