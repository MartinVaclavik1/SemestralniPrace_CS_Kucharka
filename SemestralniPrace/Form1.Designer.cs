namespace SemestralniPrace
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView_pokrmy = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_ingredience = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxTips = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_pokrmy
            // 
            this.listView_pokrmy.FullRowSelect = true;
            this.listView_pokrmy.HideSelection = false;
            this.listView_pokrmy.Location = new System.Drawing.Point(19, 30);
            this.listView_pokrmy.MultiSelect = false;
            this.listView_pokrmy.Name = "listView_pokrmy";
            this.listView_pokrmy.Size = new System.Drawing.Size(483, 246);
            this.listView_pokrmy.TabIndex = 0;
            this.listView_pokrmy.TileSize = new System.Drawing.Size(483, 36);
            this.listView_pokrmy.UseCompatibleStateImageBehavior = false;
            this.listView_pokrmy.View = System.Windows.Forms.View.Tile;
            this.listView_pokrmy.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_pokrmy_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "vypis do cmd";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jídla, co lze udělat";
            // 
            // listView_ingredience
            // 
            this.listView_ingredience.FullRowSelect = true;
            this.listView_ingredience.HideSelection = false;
            this.listView_ingredience.Location = new System.Drawing.Point(551, 30);
            this.listView_ingredience.MultiSelect = false;
            this.listView_ingredience.Name = "listView_ingredience";
            this.listView_ingredience.ShowGroups = false;
            this.listView_ingredience.Size = new System.Drawing.Size(237, 246);
            this.listView_ingredience.TabIndex = 3;
            this.listView_ingredience.UseCompatibleStateImageBehavior = false;
            this.listView_ingredience.View = System.Windows.Forms.View.Tile;
            this.listView_ingredience.DoubleClick += new System.EventHandler(this.listView_ingredience_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ingredience ve skladu";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(656, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 48);
            this.button2.TabIndex = 5;
            this.button2.Text = "přidat ingredienci do skladu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(374, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 48);
            this.button3.TabIndex = 6;
            this.button3.Text = "uprav vybraný pokrm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(228, 282);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 48);
            this.button4.TabIndex = 7;
            this.button4.Text = "zobraz všechny pokrmy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Informace";
            // 
            // checkBoxTips
            // 
            this.checkBoxTips.AutoSize = true;
            this.checkBoxTips.Location = new System.Drawing.Point(104, 295);
            this.checkBoxTips.Name = "checkBoxTips";
            this.checkBoxTips.Size = new System.Drawing.Size(103, 20);
            this.checkBoxTips.TabIndex = 8;
            this.checkBoxTips.Text = "skrýt tooltips";
            this.checkBoxTips.UseVisualStyleBackColor = true;
            this.checkBoxTips.CheckedChanged += new System.EventHandler(this.checkBoxTips_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(551, 280);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 48);
            this.button5.TabIndex = 9;
            this.button5.Text = "odeber ingredienci";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 350);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBoxTips);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView_ingredience);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView_pokrmy);
            this.Name = "Form1";
            this.Text = "Kucharka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_pokrmy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_ingredience;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBoxTips;
        private System.Windows.Forms.Button button5;
    }
}

