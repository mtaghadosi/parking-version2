namespace SoftwareMainBase.GUI
{
    partial class UpdatingInformations
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
            this.label1 = new System.Windows.Forms.Label();
            this.ViewDataGroups = new System.Windows.Forms.DataGridView();
            this.ViewDataUsrs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ViewDataGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewDataUsrs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 104);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Wait While Connecting\r\nto Database and Updating\r\nInformations\r\n\r\n\r\n\r\n\r\nThi" +
                "s may take a few seconds...";
            // 
            // ViewDataGroups
            // 
            this.ViewDataGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewDataGroups.Location = new System.Drawing.Point(0, 0);
            this.ViewDataGroups.Name = "ViewDataGroups";
            this.ViewDataGroups.Size = new System.Drawing.Size(11, 10);
            this.ViewDataGroups.TabIndex = 1;
            this.ViewDataGroups.Visible = false;
            // 
            // ViewDataUsrs
            // 
            this.ViewDataUsrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewDataUsrs.Location = new System.Drawing.Point(0, 16);
            this.ViewDataUsrs.Name = "ViewDataUsrs";
            this.ViewDataUsrs.Size = new System.Drawing.Size(11, 10);
            this.ViewDataUsrs.TabIndex = 2;
            this.ViewDataUsrs.Visible = false;
            // 
            // UpdatingInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = global::SoftwareMainBase.Properties.Resources.Info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(291, 125);
            this.Controls.Add(this.ViewDataUsrs);
            this.Controls.Add(this.ViewDataGroups);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdatingInformations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Updating Informations ...";
            this.Shown += new System.EventHandler(this.UpdatingInformations_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ViewDataGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewDataUsrs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ViewDataGroups;
        private System.Windows.Forms.DataGridView ViewDataUsrs;
    }
}