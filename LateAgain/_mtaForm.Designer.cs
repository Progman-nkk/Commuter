namespace LateAgain
{
    partial class _mtaForm
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
            this.components = new System.ComponentModel.Container();
            this.txt_summary = new System.Windows.Forms.TextBox();
            this.txt_affected = new System.Windows.Forms.TextBox();
            this.txt_consequences = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.qUITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_summary
            // 
            this.txt_summary.BackColor = System.Drawing.Color.Black;
            this.txt_summary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_summary.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_summary.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_summary.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_summary.ForeColor = System.Drawing.Color.Lime;
            this.txt_summary.Location = new System.Drawing.Point(0, 0);
            this.txt_summary.Multiline = true;
            this.txt_summary.Name = "txt_summary";
            this.txt_summary.ReadOnly = true;
            this.txt_summary.Size = new System.Drawing.Size(776, 139);
            this.txt_summary.TabIndex = 0;
            // 
            // txt_affected
            // 
            this.txt_affected.BackColor = System.Drawing.Color.Black;
            this.txt_affected.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_affected.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_affected.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_affected.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_affected.ForeColor = System.Drawing.Color.Lime;
            this.txt_affected.Location = new System.Drawing.Point(782, 0);
            this.txt_affected.Multiline = true;
            this.txt_affected.Name = "txt_affected";
            this.txt_affected.ReadOnly = true;
            this.txt_affected.Size = new System.Drawing.Size(223, 139);
            this.txt_affected.TabIndex = 2;
            this.txt_affected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_consequences
            // 
            this.txt_consequences.BackColor = System.Drawing.Color.Black;
            this.txt_consequences.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_consequences.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_consequences.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_consequences.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_consequences.ForeColor = System.Drawing.Color.Lime;
            this.txt_consequences.Location = new System.Drawing.Point(993, 0);
            this.txt_consequences.Multiline = true;
            this.txt_consequences.Name = "txt_consequences";
            this.txt_consequences.ReadOnly = true;
            this.txt_consequences.Size = new System.Drawing.Size(176, 139);
            this.txt_consequences.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qUITToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            // 
            // qUITToolStripMenuItem
            // 
            this.qUITToolStripMenuItem.Name = "qUITToolStripMenuItem";
            this.qUITToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.qUITToolStripMenuItem.Text = "QUIT";
            this.qUITToolStripMenuItem.Click += new System.EventHandler(this.qUITToolStripMenuItem_Click);
            // 
            // _mtaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1161, 141);
            this.Controls.Add(this.txt_consequences);
            this.Controls.Add(this.txt_affected);
            this.Controls.Add(this.txt_summary);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "_mtaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "lateAgain.exe";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this._mtaForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_summary;
        private System.Windows.Forms.TextBox txt_affected;
        private System.Windows.Forms.TextBox txt_consequences;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem qUITToolStripMenuItem;
    }
}

