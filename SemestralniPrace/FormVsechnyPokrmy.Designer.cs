namespace SemestralniPrace
{
    partial class FormVsechnyPokrmy
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
            this.listView_pokrmy = new System.Windows.Forms.ListView();
            this.btnUprav = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_pokrmy
            // 
            this.listView_pokrmy.FullRowSelect = true;
            this.listView_pokrmy.HideSelection = false;
            this.listView_pokrmy.Location = new System.Drawing.Point(13, 12);
            this.listView_pokrmy.MultiSelect = false;
            this.listView_pokrmy.Name = "listView_pokrmy";
            this.listView_pokrmy.Size = new System.Drawing.Size(282, 360);
            this.listView_pokrmy.TabIndex = 0;
            this.listView_pokrmy.TileSize = new System.Drawing.Size(334, 36);
            this.listView_pokrmy.UseCompatibleStateImageBehavior = false;
            this.listView_pokrmy.View = System.Windows.Forms.View.Tile;
            this.listView_pokrmy.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_pokrmy_MouseDoubleClick);
            // 
            // btnUprav
            // 
            this.btnUprav.Location = new System.Drawing.Point(301, 66);
            this.btnUprav.Name = "btnUprav";
            this.btnUprav.Size = new System.Drawing.Size(106, 48);
            this.btnUprav.TabIndex = 7;
            this.btnUprav.Text = "uprav vybraný pokrm";
            this.btnUprav.UseVisualStyleBackColor = true;
            this.btnUprav.Click += new System.EventHandler(this.btnUprav_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "vlož nový pokrm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 48);
            this.button2.TabIndex = 9;
            this.button2.Text = "odeber pokrm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(301, 324);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 48);
            this.button3.TabIndex = 10;
            this.button3.Text = "zavřít";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(301, 199);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 48);
            this.button4.TabIndex = 11;
            this.button4.Text = "co chybí?";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(301, 253);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 48);
            this.button5.TabIndex = 12;
            this.button5.Text = "odeber ingredience";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormVsechnyPokrmy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 384);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUprav);
            this.Controls.Add(this.listView_pokrmy);
            this.Name = "FormVsechnyPokrmy";
            this.Text = "FormVsechnyPokrmy";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_pokrmy;
        private System.Windows.Forms.Button btnUprav;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}