
namespace ConnectionUpdater
{
    partial class ConnectionUpdaterControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_folder_path = new System.Windows.Forms.TextBox();
            this.btn_folder_selector = new System.Windows.Forms.Button();
            this.tb_logging = new System.Windows.Forms.TextBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_folder_path, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_folder_selector, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_logging, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_update, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 300);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection folder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_folder_path
            // 
            this.tb_folder_path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_folder_path.Location = new System.Drawing.Point(102, 4);
            this.tb_folder_path.Name = "tb_folder_path";
            this.tb_folder_path.Size = new System.Drawing.Size(292, 20);
            this.tb_folder_path.TabIndex = 1;
            // 
            // btn_folder_selector
            // 
            this.btn_folder_selector.Location = new System.Drawing.Point(400, 3);
            this.btn_folder_selector.Name = "btn_folder_selector";
            this.btn_folder_selector.Size = new System.Drawing.Size(75, 23);
            this.btn_folder_selector.TabIndex = 2;
            this.btn_folder_selector.Text = "...";
            this.btn_folder_selector.UseVisualStyleBackColor = true;
            this.btn_folder_selector.Click += new System.EventHandler(this.btn_folder_selector_Click);
            // 
            // tb_logging
            // 
            this.tb_logging.AcceptsReturn = true;
            this.tableLayoutPanel1.SetColumnSpan(this.tb_logging, 4);
            this.tb_logging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_logging.Location = new System.Drawing.Point(3, 32);
            this.tb_logging.Multiline = true;
            this.tb_logging.Name = "tb_logging";
            this.tb_logging.ReadOnly = true;
            this.tb_logging.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_logging.Size = new System.Drawing.Size(553, 265);
            this.tb_logging.TabIndex = 4;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(481, 3);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 3;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // ConnectionUpdaterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectionUpdaterControl";
            this.Size = new System.Drawing.Size(559, 300);
            this.Load += new System.EventHandler(this.ConnectionUpdaterControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_folder_path;
        private System.Windows.Forms.Button btn_folder_selector;
        private System.Windows.Forms.TextBox tb_logging;
        private System.Windows.Forms.Button btn_update;
    }
}
