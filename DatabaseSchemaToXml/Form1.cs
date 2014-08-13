using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using DatabaseSchemaToXml.Classes.Discovery;

namespace DatabaseSchemaToXml
{
    public partial class Form1 : Form
    {
        #region Property - XmlFilePath
        private string _xmlFilePath;
        private string XmlFilePath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_xmlFilePath))
                {
                    _xmlFilePath = Path.Combine(Application.StartupPath, "Schema.xml");

                    try
                    {
                        if (!File.Exists(_xmlFilePath))
                        {
                            File.Create(_xmlFilePath).Close();
                        }
                    }
                    catch
                    {
                        //Cant write to application startup path, use temp dir instead.
                        _xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Schema.xml");
                        try
                        {
                            File.Create(_xmlFilePath).Close();
                        }
                        catch
                        {
                            _xmlFilePath = null;
                        }
                    }
                }
                return _xmlFilePath;
            }
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void uxButton_Generate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.uxTextBox_Database.Text) ||
                String.IsNullOrWhiteSpace(this.uxTextBox_Server.Text))
            {
                return;
            }

            //DeserializeSchema();

            GenerateSchemaXml();

            //CompareSchema();
        }

        private void DeserializeSchema()
        {
            Database schema = SchemaSerializer.Deserialize(this.XmlFilePath);
        }

        private void GenerateSchemaXml()
        {
            DatabaseSchemaService.Generate(GetConnectionString()).Serialize(this.XmlFilePath);
        }

        private void CompareSchema()
        {
            Database schemaA = SchemaSerializer.Deserialize(this.XmlFilePath);

            Database schemaB = DatabaseSchemaService.Generate(GetConnectionString());

            SchemaComparisonResult result = schemaA.Compare(schemaB);
        }

        private string GetConnectionString()
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = this.uxTextBox_Server.Text,
                InitialCatalog = this.uxTextBox_Database.Text,
                IntegratedSecurity = true
            }.ToString();
        }
    }
}
