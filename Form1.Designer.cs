namespace Xp_Table_Test
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_interv_presta = new System.Windows.Forms.TextBox();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.textBox_gauche = new System.Windows.Forms.TextBox();
            this.textBox_droite = new System.Windows.Forms.TextBox();
            this.table = new XPTable.Models.Table();
            this.columnModel1 = new XPTable.Models.ColumnModel();
            this.paroi_textColumn = new XPTable.Models.TextColumn();
            this.nv_Column = new XPTable.Models.CheckBoxColumn();
            this.nc_column = new XPTable.Models.CheckBoxColumn();
            this.c_Column = new XPTable.Models.CheckBoxColumn();
            this.commentaire_Column = new XPTable.Models.TextColumn();
            this.tableModel = new XPTable.Models.TableModel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBox_diagnostic = new System.Windows.Forms.TextBox();
            this.textBox_date = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(421, 11);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(444, 91);
            this.textBox1.TabIndex = 0;
            // 
            // textBox_interv_presta
            // 
            this.textBox_interv_presta.Location = new System.Drawing.Point(70, 118);
            this.textBox_interv_presta.Multiline = true;
            this.textBox_interv_presta.Name = "textBox_interv_presta";
            this.textBox_interv_presta.Size = new System.Drawing.Size(795, 60);
            this.textBox_interv_presta.TabIndex = 1;
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(70, 184);
            this.textBox_title.Multiline = true;
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(795, 44);
            this.textBox_title.TabIndex = 2;
            // 
            // textBox_gauche
            // 
            this.textBox_gauche.Location = new System.Drawing.Point(70, 251);
            this.textBox_gauche.Multiline = true;
            this.textBox_gauche.Name = "textBox_gauche";
            this.textBox_gauche.Size = new System.Drawing.Size(423, 88);
            this.textBox_gauche.TabIndex = 3;
            // 
            // textBox_droite
            // 
            this.textBox_droite.Location = new System.Drawing.Point(499, 251);
            this.textBox_droite.Multiline = true;
            this.textBox_droite.Name = "textBox_droite";
            this.textBox_droite.Size = new System.Drawing.Size(366, 88);
            this.textBox_droite.TabIndex = 4;
            // 
            // table
            // 
            this.table.AllowDrop = true;
            this.table.AlternatingRowColor = System.Drawing.SystemColors.ActiveBorder;
            this.table.ColumnModel = this.columnModel1;
            this.table.GridLines = XPTable.Models.GridLines.Both;
            this.table.Location = new System.Drawing.Point(70, 367);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(795, 239);
            this.table.TabIndex = 5;
            this.table.TableModel = this.tableModel;
            this.table.Text = "table1";
            // 
            // columnModel1
            // 
            this.columnModel1.Columns.AddRange(new XPTable.Models.Column[] {
            this.paroi_textColumn,
            this.nv_Column,
            this.nc_column,
            this.c_Column,
            this.commentaire_Column});
            // 
            // paroi_textColumn
            // 
            this.paroi_textColumn.Text = "Parois Verticales";
            this.paroi_textColumn.Width = 400;
            // 
            // nv_Column
            // 
            this.nv_Column.Text = "NV";
            this.nv_Column.Width = 30;
            // 
            // nc_column
            // 
            this.nc_column.Text = "NC";
            this.nc_column.Width = 30;
            // 
            // c_Column
            // 
            this.c_Column.Text = "C";
            this.c_Column.Width = 30;
            // 
            // commentaire_Column
            // 
            this.commentaire_Column.Text = "Commentaires";
            this.commentaire_Column.Width = 200;
            // 
            // tableModel
            // 
            this.tableModel.RowHeight = 30;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(70, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(146, 90);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // textBox_diagnostic
            // 
            this.textBox_diagnostic.Location = new System.Drawing.Point(70, 632);
            this.textBox_diagnostic.Multiline = true;
            this.textBox_diagnostic.Name = "textBox_diagnostic";
            this.textBox_diagnostic.Size = new System.Drawing.Size(412, 64);
            this.textBox_diagnostic.TabIndex = 7;
            // 
            // textBox_date
            // 
            this.textBox_date.Location = new System.Drawing.Point(480, 632);
            this.textBox_date.Multiline = true;
            this.textBox_date.Name = "textBox_date";
            this.textBox_date.Size = new System.Drawing.Size(385, 64);
            this.textBox_date.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(919, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Generer PDF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1084, 708);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_date);
            this.Controls.Add(this.textBox_diagnostic);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.table);
            this.Controls.Add(this.textBox_droite);
            this.Controls.Add(this.textBox_gauche);
            this.Controls.Add(this.textBox_title);
            this.Controls.Add(this.textBox_interv_presta);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_interv_presta;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.TextBox textBox_gauche;
        private System.Windows.Forms.TextBox textBox_droite;
        private XPTable.Models.Table table;
        private XPTable.Models.TextColumn paroi_textColumn;
        private XPTable.Models.CheckBoxColumn nv_Column;
        private XPTable.Models.CheckBoxColumn nc_column;
        private XPTable.Models.CheckBoxColumn c_Column;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBox_diagnostic;
        private System.Windows.Forms.TextBox textBox_date;
        private System.Windows.Forms.Button button2;
        public XPTable.Models.ColumnModel columnModel1;
        private XPTable.Models.TextColumn commentaire_Column;
        private XPTable.Models.TableModel tableModel;
    }
}

