namespace OGAniEditorWinForms
{
    partial class Editor
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
            this.xnaSurface = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.xnaSurface)).BeginInit();
            this.SuspendLayout();
            // 
            // xnaSurface
            // 
            this.xnaSurface.Location = new System.Drawing.Point(9, 9);
            this.xnaSurface.Margin = new System.Windows.Forms.Padding(0);
            this.xnaSurface.Name = "xnaSurface";
            this.xnaSurface.Size = new System.Drawing.Size(1280, 720);
            this.xnaSurface.TabIndex = 0;
            this.xnaSurface.TabStop = false;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 740);
            this.ControlBox = false;
            this.Controls.Add(this.xnaSurface);
            this.Name = "Editor";
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.xnaSurface)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox xnaSurface;
    }
}