namespace SemestralniPrace
{
    partial class FormKontrolaOdebraniIngredienci
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
            this.dataGridViewIngredience = new System.Windows.Forms.DataGridView();
            this.Ingredience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngredience)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewIngredience
            // 
            this.dataGridViewIngredience.AllowUserToAddRows = false;
            this.dataGridViewIngredience.AllowUserToDeleteRows = false;
            this.dataGridViewIngredience.AllowUserToResizeColumns = false;
            this.dataGridViewIngredience.AllowUserToResizeRows = false;
            this.dataGridViewIngredience.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIngredience.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIngredience.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ingredience,
            this.pocet});
            this.dataGridViewIngredience.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewIngredience.Location = new System.Drawing.Point(12, 74);
            this.dataGridViewIngredience.MultiSelect = false;
            this.dataGridViewIngredience.Name = "dataGridViewIngredience";
            this.dataGridViewIngredience.RowHeadersVisible = false;
            this.dataGridViewIngredience.RowHeadersWidth = 51;
            this.dataGridViewIngredience.RowTemplate.Height = 24;
            this.dataGridViewIngredience.Size = new System.Drawing.Size(321, 245);
            this.dataGridViewIngredience.TabIndex = 11;
            this.dataGridViewIngredience.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewIngredience_CellBeginEdit);
            this.dataGridViewIngredience.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIngredience_CellEndEdit);
            this.dataGridViewIngredience.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewIngredience_DataError);
            // 
            // Ingredience
            // 
            this.Ingredience.HeaderText = "Ingredience";
            this.Ingredience.MinimumWidth = 6;
            this.Ingredience.Name = "Ingredience";
            this.Ingredience.ReadOnly = true;
            // 
            // pocet
            // 
            this.pocet.HeaderText = "počet (ks)/ hmotnost (g)";
            this.pocet.MinimumWidth = 6;
            this.pocet.Name = "pocet";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(177, 324);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 33);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(258, 325);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 48);
            this.label1.TabIndex = 14;
            this.label1.Text = "Zkontrolujte, popř upravte použitý počet ingrediencí\r\n\r\nV případě nepoužité ingre" +
    "dience vložte 0";
            // 
            // FormKontrolaOdebraniIngredienci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dataGridViewIngredience);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormKontrolaOdebraniIngredienci";
            this.Text = "FormKontrolaOdebraniIngredienci";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngredience)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewIngredience;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredience;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocet;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
    }
}