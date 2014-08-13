namespace DatabaseSchemaToXml
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxLabel_Server = new System.Windows.Forms.Label();
            this.uxTextBox_Server = new System.Windows.Forms.TextBox();
            this.uxTextBox_Database = new System.Windows.Forms.TextBox();
            this.uxLabel_Database = new System.Windows.Forms.Label();
            this.uxButton_Generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxLabel_Server
            // 
            this.uxLabel_Server.AutoSize = true;
            this.uxLabel_Server.Location = new System.Drawing.Point(40, 22);
            this.uxLabel_Server.Name = "uxLabel_Server";
            this.uxLabel_Server.Size = new System.Drawing.Size(41, 13);
            this.uxLabel_Server.TabIndex = 0;
            this.uxLabel_Server.Text = "Server:";
            // 
            // uxTextBox_Server
            // 
            this.uxTextBox_Server.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxTextBox_Server.Location = new System.Drawing.Point(87, 19);
            this.uxTextBox_Server.Name = "uxTextBox_Server";
            this.uxTextBox_Server.Size = new System.Drawing.Size(215, 20);
            this.uxTextBox_Server.TabIndex = 1;
            this.uxTextBox_Server.Text = "localhost";
            // 
            // uxTextBox_Database
            // 
            this.uxTextBox_Database.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxTextBox_Database.Location = new System.Drawing.Point(87, 45);
            this.uxTextBox_Database.Name = "uxTextBox_Database";
            this.uxTextBox_Database.Size = new System.Drawing.Size(215, 20);
            this.uxTextBox_Database.TabIndex = 3;
            this.uxTextBox_Database.Text = "cAsset";
            // 
            // uxLabel_Database
            // 
            this.uxLabel_Database.AutoSize = true;
            this.uxLabel_Database.Location = new System.Drawing.Point(25, 48);
            this.uxLabel_Database.Name = "uxLabel_Database";
            this.uxLabel_Database.Size = new System.Drawing.Size(56, 13);
            this.uxLabel_Database.TabIndex = 2;
            this.uxLabel_Database.Text = "Database:";
            // 
            // uxButton_Generate
            // 
            this.uxButton_Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxButton_Generate.Location = new System.Drawing.Point(208, 76);
            this.uxButton_Generate.Name = "uxButton_Generate";
            this.uxButton_Generate.Size = new System.Drawing.Size(94, 23);
            this.uxButton_Generate.TabIndex = 4;
            this.uxButton_Generate.Text = "Generate XML";
            this.uxButton_Generate.UseVisualStyleBackColor = true;
            this.uxButton_Generate.Click += new System.EventHandler(this.uxButton_Generate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 111);
            this.Controls.Add(this.uxButton_Generate);
            this.Controls.Add(this.uxTextBox_Database);
            this.Controls.Add(this.uxLabel_Database);
            this.Controls.Add(this.uxTextBox_Server);
            this.Controls.Add(this.uxLabel_Server);
            this.Name = "Form1";
            this.Text = "Database Schema to XML Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxLabel_Server;
        private System.Windows.Forms.TextBox uxTextBox_Server;
        private System.Windows.Forms.TextBox uxTextBox_Database;
        private System.Windows.Forms.Label uxLabel_Database;
        private System.Windows.Forms.Button uxButton_Generate;
    }
}

