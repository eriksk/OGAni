namespace OGAniEditorWinForms
{
    partial class Animations
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
            this.listBoxAnimations = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCloneAnimation = new System.Windows.Forms.Button();
            this.buttonDeleteAnimation = new System.Windows.Forms.Button();
            this.buttonNewAnimation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxFrames = new System.Windows.Forms.ListBox();
            this.buttonKeyframe = new System.Windows.Forms.Button();
            this.buttonDeleteFrame = new System.Windows.Forms.Button();
            this.buttonNewFrame = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSaveKeyframe = new System.Windows.Forms.Button();
            this.richTextBoxScript = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonDeleteKeyframe = new System.Windows.Forms.Button();
            this.listBoxKeyframes = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxAnimations
            // 
            this.listBoxAnimations.FormattingEnabled = true;
            this.listBoxAnimations.Location = new System.Drawing.Point(6, 19);
            this.listBoxAnimations.Name = "listBoxAnimations";
            this.listBoxAnimations.ScrollAlwaysVisible = true;
            this.listBoxAnimations.Size = new System.Drawing.Size(191, 212);
            this.listBoxAnimations.Sorted = true;
            this.listBoxAnimations.TabIndex = 0;
            this.listBoxAnimations.SelectedIndexChanged += new System.EventHandler(this.listBoxAnimations_SelectedIndexChanged);
            this.listBoxAnimations.DoubleClick += new System.EventHandler(this.listBoxAnimations_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCloneAnimation);
            this.groupBox1.Controls.Add(this.buttonDeleteAnimation);
            this.groupBox1.Controls.Add(this.buttonNewAnimation);
            this.groupBox1.Controls.Add(this.listBoxAnimations);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 271);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animations";
            // 
            // buttonCloneAnimation
            // 
            this.buttonCloneAnimation.Location = new System.Drawing.Point(150, 237);
            this.buttonCloneAnimation.Name = "buttonCloneAnimation";
            this.buttonCloneAnimation.Size = new System.Drawing.Size(47, 23);
            this.buttonCloneAnimation.TabIndex = 1;
            this.buttonCloneAnimation.Text = "Clone";
            this.buttonCloneAnimation.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteAnimation
            // 
            this.buttonDeleteAnimation.Location = new System.Drawing.Point(56, 237);
            this.buttonDeleteAnimation.Name = "buttonDeleteAnimation";
            this.buttonDeleteAnimation.Size = new System.Drawing.Size(47, 23);
            this.buttonDeleteAnimation.TabIndex = 1;
            this.buttonDeleteAnimation.Text = "Delete";
            this.buttonDeleteAnimation.UseVisualStyleBackColor = true;
            this.buttonDeleteAnimation.Click += new System.EventHandler(this.buttonDeleteAnimation_Click);
            // 
            // buttonNewAnimation
            // 
            this.buttonNewAnimation.Location = new System.Drawing.Point(6, 237);
            this.buttonNewAnimation.Name = "buttonNewAnimation";
            this.buttonNewAnimation.Size = new System.Drawing.Size(44, 23);
            this.buttonNewAnimation.TabIndex = 1;
            this.buttonNewAnimation.Text = "New";
            this.buttonNewAnimation.UseVisualStyleBackColor = true;
            this.buttonNewAnimation.Click += new System.EventHandler(this.buttonNewAnimation_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxFrames);
            this.groupBox2.Controls.Add(this.buttonKeyframe);
            this.groupBox2.Controls.Add(this.buttonDeleteFrame);
            this.groupBox2.Controls.Add(this.buttonNewFrame);
            this.groupBox2.Location = new System.Drawing.Point(221, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 271);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Frames";
            // 
            // listBoxFrames
            // 
            this.listBoxFrames.FormattingEnabled = true;
            this.listBoxFrames.Location = new System.Drawing.Point(6, 19);
            this.listBoxFrames.Name = "listBoxFrames";
            this.listBoxFrames.ScrollAlwaysVisible = true;
            this.listBoxFrames.Size = new System.Drawing.Size(191, 212);
            this.listBoxFrames.Sorted = true;
            this.listBoxFrames.TabIndex = 0;
            this.listBoxFrames.SelectedIndexChanged += new System.EventHandler(this.listBoxFrames_SelectedIndexChanged);
            this.listBoxFrames.DoubleClick += new System.EventHandler(this.listBoxFrames_DoubleClick);
            // 
            // buttonKeyframe
            // 
            this.buttonKeyframe.Location = new System.Drawing.Point(112, 237);
            this.buttonKeyframe.Name = "buttonKeyframe";
            this.buttonKeyframe.Size = new System.Drawing.Size(85, 23);
            this.buttonKeyframe.TabIndex = 1;
            this.buttonKeyframe.Text = "Keyframe";
            this.buttonKeyframe.UseVisualStyleBackColor = true;
            this.buttonKeyframe.Click += new System.EventHandler(this.buttonKeyframe_Click);
            // 
            // buttonDeleteFrame
            // 
            this.buttonDeleteFrame.Location = new System.Drawing.Point(59, 237);
            this.buttonDeleteFrame.Name = "buttonDeleteFrame";
            this.buttonDeleteFrame.Size = new System.Drawing.Size(47, 23);
            this.buttonDeleteFrame.TabIndex = 1;
            this.buttonDeleteFrame.Text = "Delete";
            this.buttonDeleteFrame.UseVisualStyleBackColor = true;
            this.buttonDeleteFrame.Click += new System.EventHandler(this.buttonDeleteFrame_Click);
            // 
            // buttonNewFrame
            // 
            this.buttonNewFrame.Location = new System.Drawing.Point(6, 237);
            this.buttonNewFrame.Name = "buttonNewFrame";
            this.buttonNewFrame.Size = new System.Drawing.Size(47, 23);
            this.buttonNewFrame.TabIndex = 1;
            this.buttonNewFrame.Text = "New";
            this.buttonNewFrame.UseVisualStyleBackColor = true;
            this.buttonNewFrame.Click += new System.EventHandler(this.buttonNewFrame_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSaveKeyframe);
            this.groupBox3.Controls.Add(this.richTextBoxScript);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxDuration);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.buttonDeleteKeyframe);
            this.groupBox3.Controls.Add(this.listBoxKeyframes);
            this.groupBox3.Location = new System.Drawing.Point(12, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 271);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Keyframes";
            // 
            // buttonSaveKeyframe
            // 
            this.buttonSaveKeyframe.Location = new System.Drawing.Point(351, 237);
            this.buttonSaveKeyframe.Name = "buttonSaveKeyframe";
            this.buttonSaveKeyframe.Size = new System.Drawing.Size(49, 23);
            this.buttonSaveKeyframe.TabIndex = 7;
            this.buttonSaveKeyframe.Text = "Save";
            this.buttonSaveKeyframe.UseVisualStyleBackColor = true;
            this.buttonSaveKeyframe.Click += new System.EventHandler(this.buttonSaveKeyframe_Click);
            // 
            // richTextBoxScript
            // 
            this.richTextBoxScript.Location = new System.Drawing.Point(209, 74);
            this.richTextBoxScript.Name = "richTextBoxScript";
            this.richTextBoxScript.Size = new System.Drawing.Size(191, 157);
            this.richTextBoxScript.TabIndex = 6;
            this.richTextBoxScript.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Script";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Duration";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(209, 35);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(100, 20);
            this.textBoxDuration.TabIndex = 2;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(150, 237);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 23);
            this.button7.TabIndex = 1;
            this.button7.Text = "Clone";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteKeyframe
            // 
            this.buttonDeleteKeyframe.Location = new System.Drawing.Point(6, 237);
            this.buttonDeleteKeyframe.Name = "buttonDeleteKeyframe";
            this.buttonDeleteKeyframe.Size = new System.Drawing.Size(47, 23);
            this.buttonDeleteKeyframe.TabIndex = 1;
            this.buttonDeleteKeyframe.Text = "Delete";
            this.buttonDeleteKeyframe.UseVisualStyleBackColor = true;
            // 
            // listBoxKeyframes
            // 
            this.listBoxKeyframes.FormattingEnabled = true;
            this.listBoxKeyframes.Location = new System.Drawing.Point(6, 19);
            this.listBoxKeyframes.Name = "listBoxKeyframes";
            this.listBoxKeyframes.ScrollAlwaysVisible = true;
            this.listBoxKeyframes.Size = new System.Drawing.Size(191, 212);
            this.listBoxKeyframes.Sorted = true;
            this.listBoxKeyframes.TabIndex = 0;
            this.listBoxKeyframes.SelectedIndexChanged += new System.EventHandler(this.listBoxKeyframes_SelectedIndexChanged);
            // 
            // Animations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 573);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Animations";
            this.ShowIcon = false;
            this.Text = "Animations";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAnimations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCloneAnimation;
        private System.Windows.Forms.Button buttonDeleteAnimation;
        private System.Windows.Forms.Button buttonNewAnimation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxFrames;
        private System.Windows.Forms.Button buttonKeyframe;
        private System.Windows.Forms.Button buttonDeleteFrame;
        private System.Windows.Forms.Button buttonNewFrame;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonDeleteKeyframe;
        private System.Windows.Forms.ListBox listBoxKeyframes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.Button buttonSaveKeyframe;
        private System.Windows.Forms.RichTextBox richTextBoxScript;
    }
}