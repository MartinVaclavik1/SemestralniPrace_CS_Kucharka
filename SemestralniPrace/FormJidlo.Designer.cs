namespace SemestralniPrace
{
    partial class FormJidlo
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
            this.listViewIngrediencePokrmu = new System.Windows.Forms.ListView();
            this.textBoxNazevPokrmu = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPridej = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewIngrediencePokrmu
            // 
            this.listViewIngrediencePokrmu.FullRowSelect = true;
            this.listViewIngrediencePokrmu.HideSelection = false;
            this.listViewIngrediencePokrmu.Location = new System.Drawing.Point(25, 88);
            this.listViewIngrediencePokrmu.MultiSelect = false;
            this.listViewIngrediencePokrmu.Name = "listViewIngrediencePokrmu";
            this.listViewIngrediencePokrmu.Size = new System.Drawing.Size(288, 131);
            this.listViewIngrediencePokrmu.TabIndex = 0;
            this.listViewIngrediencePokrmu.UseCompatibleStateImageBehavior = false;
            this.listViewIngrediencePokrmu.View = System.Windows.Forms.View.Tile;
            // 
            // textBoxNazevPokrmu
            // 
            this.textBoxNazevPokrmu.Location = new System.Drawing.Point(25, 35);
            this.textBoxNazevPokrmu.Name = "textBoxNazevPokrmu";
            this.textBoxNazevPokrmu.Size = new System.Drawing.Size(288, 22);
            this.textBoxNazevPokrmu.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(225, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "storno";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPridej
            // 
            this.btnPridej.Location = new System.Drawing.Point(25, 225);
            this.btnPridej.Name = "btnPridej";
            this.btnPridej.Size = new System.Drawing.Size(100, 44);
            this.btnPridej.TabIndex = 4;
            this.btnPridej.Text = "Přidat ingredienci";
            this.btnPridej.UseVisualStyleBackColor = true;
            this.btnPridej.Click += new System.EventHandler(this.btnPridej_Click);
            // 
            // FormJidlo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 288);
            this.Controls.Add(this.btnPridej);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxNazevPokrmu);
            this.Controls.Add(this.listViewIngrediencePokrmu);
            this.Name = "FormJidlo";
            this.Text = "FormJidlo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewIngrediencePokrmu;
        private System.Windows.Forms.TextBox textBoxNazevPokrmu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPridej;
    }
}