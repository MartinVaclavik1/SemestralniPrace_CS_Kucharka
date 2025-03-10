namespace SemestralniPrace
{
    partial class FormHledaniIngredienci
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
            this.comboIngredience = new System.Windows.Forms.ComboBox();
            this.numericUpDownPocet = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxNovy = new System.Windows.Forms.TextBox();
            this.btnZpet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocet)).BeginInit();
            this.SuspendLayout();
            // 
            // comboIngredience
            // 
            this.comboIngredience.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIngredience.FormattingEnabled = true;
            this.comboIngredience.Location = new System.Drawing.Point(28, 31);
            this.comboIngredience.Name = "comboIngredience";
            this.comboIngredience.Size = new System.Drawing.Size(279, 24);
            this.comboIngredience.TabIndex = 1;
            this.comboIngredience.SelectedIndexChanged += new System.EventHandler(this.comboIngredience_SelectedIndexChanged);
            // 
            // numericUpDownPocet
            // 
            this.numericUpDownPocet.Location = new System.Drawing.Point(28, 72);
            this.numericUpDownPocet.Name = "numericUpDownPocet";
            this.numericUpDownPocet.Size = new System.Drawing.Size(279, 22);
            this.numericUpDownPocet.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(156, 117);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBoxNovy
            // 
            this.textBoxNovy.Location = new System.Drawing.Point(28, 33);
            this.textBoxNovy.Name = "textBoxNovy";
            this.textBoxNovy.Size = new System.Drawing.Size(198, 22);
            this.textBoxNovy.TabIndex = 5;
            this.textBoxNovy.Visible = false;
            // 
            // btnZpet
            // 
            this.btnZpet.Location = new System.Drawing.Point(237, 28);
            this.btnZpet.Name = "btnZpet";
            this.btnZpet.Size = new System.Drawing.Size(70, 28);
            this.btnZpet.TabIndex = 6;
            this.btnZpet.Text = "vrátit ";
            this.btnZpet.UseVisualStyleBackColor = true;
            this.btnZpet.Visible = false;
            this.btnZpet.Click += new System.EventHandler(this.btnZpet_Click);
            // 
            // FormHledaniIngredienci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 152);
            this.Controls.Add(this.btnZpet);
            this.Controls.Add(this.textBoxNovy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.numericUpDownPocet);
            this.Controls.Add(this.comboIngredience);
            this.Name = "FormHledaniIngredienci";
            this.Text = "FormHledaniIngredienci";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboIngredience;
        private System.Windows.Forms.NumericUpDown numericUpDownPocet;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBoxNovy;
        private System.Windows.Forms.Button btnZpet;
    }
}