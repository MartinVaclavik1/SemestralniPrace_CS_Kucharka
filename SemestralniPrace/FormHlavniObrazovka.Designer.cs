namespace SemestralniPrace
{
    partial class FormHlavniObrazovka
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
            this.label1 = new System.Windows.Forms.Label();
            this.listView_ingredience = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxTips = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridViewIngredience = new System.Windows.Forms.DataGridView();
            this.Ingredience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngredience)).BeginInit();
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
            this.listView_pokrmy.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_pokrmy.TabIndex = 0;
            this.listView_pokrmy.TileSize = new System.Drawing.Size(483, 36);
            this.listView_pokrmy.UseCompatibleStateImageBehavior = false;
            this.listView_pokrmy.View = System.Windows.Forms.View.Tile;
            this.listView_pokrmy.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_pokrmy_MouseDoubleClick);
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
            this.listView_ingredience.Size = new System.Drawing.Size(270, 246);
            this.listView_ingredience.Sorting = System.Windows.Forms.SortOrder.Ascending;
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
            this.button2.Location = new System.Drawing.Point(689, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 58);
            this.button2.TabIndex = 5;
            this.button2.Text = "přidat ingredienci do skladu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(153, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 56);
            this.button3.TabIndex = 6;
            this.button3.Text = "uprav vybraný pokrm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(19, 282);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 56);
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
            this.checkBoxTips.Location = new System.Drawing.Point(399, 301);
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
            this.button5.Size = new System.Drawing.Size(132, 58);
            this.button5.TabIndex = 9;
            this.button5.Text = "odeber ingredienci ze skladu";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.dataGridViewIngredience.Location = new System.Drawing.Point(326, 28);
            this.dataGridViewIngredience.MultiSelect = false;
            this.dataGridViewIngredience.Name = "dataGridViewIngredience";
            this.dataGridViewIngredience.RowHeadersVisible = false;
            this.dataGridViewIngredience.RowHeadersWidth = 51;
            this.dataGridViewIngredience.RowTemplate.Height = 24;
            this.dataGridViewIngredience.Size = new System.Drawing.Size(270, 245);
            this.dataGridViewIngredience.TabIndex = 10;
            this.dataGridViewIngredience.Visible = false;
            this.dataGridViewIngredience.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIngredience_CellEndEdit);
            this.dataGridViewIngredience.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIngredience_CellValueChanged);
            // 
            // Ingredience
            // 
            this.Ingredience.HeaderText = "Ingredience";
            this.Ingredience.MinimumWidth = 6;
            this.Ingredience.Name = "Ingredience";
            // 
            // pocet
            // 
            this.pocet.HeaderText = "počet (ks)/ hmotnost (g)";
            this.pocet.MinimumWidth = 6;
            this.pocet.Name = "pocet";
            // 
            // FormHlavniObrazovka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 350);
            this.Controls.Add(this.dataGridViewIngredience);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBoxTips);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView_ingredience);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView_pokrmy);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(852, 397);
            this.MinimumSize = new System.Drawing.Size(852, 397);
            this.Name = "FormHlavniObrazovka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kucharka";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngredience)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_pokrmy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_ingredience;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBoxTips;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridViewIngredience;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredience;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocet;
    }
}

