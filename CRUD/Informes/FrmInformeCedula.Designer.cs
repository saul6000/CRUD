namespace CRUD.Informes
{
    partial class FrmInformeCedula
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsCedula = new CRUD.Ds.dsCedula();
            this.dsCedulaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datosPersonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datos_PersonasTableAdapter = new CRUD.Ds.dsCedulaTableAdapters.Datos_PersonasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsCedula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCedulaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosPersonasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.datosPersonasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CRUD.Informes.rptCedula.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsCedula
            // 
            this.dsCedula.DataSetName = "dsCedula";
            this.dsCedula.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsCedulaBindingSource
            // 
            this.dsCedulaBindingSource.DataSource = this.dsCedula;
            this.dsCedulaBindingSource.Position = 0;
            // 
            // datosPersonasBindingSource
            // 
            this.datosPersonasBindingSource.DataMember = "Datos_Personas";
            this.datosPersonasBindingSource.DataSource = this.dsCedulaBindingSource;
            // 
            // datos_PersonasTableAdapter
            // 
            this.datos_PersonasTableAdapter.ClearBeforeFill = true;
            // 
            // FrmInformeCedula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmInformeCedula";
            this.Text = "FrmInformeEstudiantes";
            this.Load += new System.EventHandler(this.FrmInformeCedula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsCedula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCedulaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosPersonasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dsCedulaBindingSource;
        private Ds.dsCedula dsCedula;
        private System.Windows.Forms.BindingSource datosPersonasBindingSource;
        private Ds.dsCedulaTableAdapters.Datos_PersonasTableAdapter datos_PersonasTableAdapter;
    }
}