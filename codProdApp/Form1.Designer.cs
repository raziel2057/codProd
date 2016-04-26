namespace codProdApp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtGVResultado = new System.Windows.Forms.DataGridView();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGVResultado
            // 
            this.dtGVResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVResultado.Location = new System.Drawing.Point(68, 35);
            this.dtGVResultado.Name = "dtGVResultado";
            this.dtGVResultado.RowTemplate.Height = 24;
            this.dtGVResultado.Size = new System.Drawing.Size(1406, 527);
            this.dtGVResultado.TabIndex = 0;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(289, 579);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 1;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(432, 578);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(120, 23);
            this.btnCSV.TabIndex = 2;
            this.btnCSV.Text = "Guardar CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 640);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dtGVResultado);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGVResultado;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnCSV;
    }
}

