using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DatabaseSchemaToXml
{
    public static class SchemaSerializer
    {
        #region Property - Serializer
        private static object _serializerLock = new object();
        private static XmlSerializer _serializer = null;
        private static XmlSerializer Serializer
        {
            get
            {
                if (_serializer == null)
                {
                    lock (_serializerLock)
                    {
                        if (_serializer == null)
                        {
                            _serializer = new XmlSerializer(typeof(Database));
                        }
                    }
                }
                return _serializer;
            }
        }
        #endregion

        #region Method - Deserialize
        /// <summary>
        /// Reads the specified file and deserializes it.
        /// </summary>
        public static Database Deserialize(string inputPath)
        {
            Database deserializedSchema = null;

            using (StreamReader reader = new StreamReader(inputPath))
            {
                deserializedSchema = Serializer.Deserialize(reader) as Database;
            }

            return deserializedSchema;
        }
        #endregion

        #region Method - Serialize
        /// <summary>
        /// Serializes the current schema information to the supplied file.
        /// </summary>
        public static void Serialize(this Database schema, string outputPath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;

            using (XmlWriter sw = XmlWriter.Create(outputPath, settings))
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(String.Empty, String.Empty);

                Serializer.Serialize(sw, schema, namespaces);
            }
        }
        #endregion
    }
}
