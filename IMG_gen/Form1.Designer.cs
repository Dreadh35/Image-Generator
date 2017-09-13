namespace IMG_gen {
    partial class Form1 {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.picOutput = new System.Windows.Forms.PictureBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.jumRange = new System.Windows.Forms.MaskedTextBox();
            this.Jumprange = new System.Windows.Forms.Label();
            this.drawSelect = new System.Windows.Forms.GroupBox();
            this.arcs = new System.Windows.Forms.RadioButton();
            this.lines = new System.Windows.Forms.RadioButton();
            this.noise = new System.Windows.Forms.RadioButton();
            this.random = new System.Windows.Forms.RadioButton();
            this.randomColor = new System.Windows.Forms.CheckBox();
            this.saveImage = new System.Windows.Forms.Button();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
            this.drawSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // picOutput
            // 
            this.picOutput.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOutput.Location = new System.Drawing.Point(12, 137);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(400, 400);
            this.picOutput.TabIndex = 0;
            this.picOutput.TabStop = false;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(12, 12);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // jumRange
            // 
            this.jumRange.Location = new System.Drawing.Point(104, 93);
            this.jumRange.Mask = "000";
            this.jumRange.Name = "jumRange";
            this.jumRange.PromptChar = ' ';
            this.jumRange.Size = new System.Drawing.Size(41, 20);
            this.jumRange.TabIndex = 2;
            this.jumRange.Text = "20";
            // 
            // Jumprange
            // 
            this.Jumprange.AutoSize = true;
            this.Jumprange.Location = new System.Drawing.Point(17, 96);
            this.Jumprange.Name = "Jumprange";
            this.Jumprange.Size = new System.Drawing.Size(81, 13);
            this.Jumprange.TabIndex = 3;
            this.Jumprange.Text = "Colordifference:";
            // 
            // drawSelect
            // 
            this.drawSelect.Controls.Add(this.random);
            this.drawSelect.Controls.Add(this.arcs);
            this.drawSelect.Controls.Add(this.lines);
            this.drawSelect.Controls.Add(this.noise);
            this.drawSelect.Location = new System.Drawing.Point(13, 42);
            this.drawSelect.Name = "drawSelect";
            this.drawSelect.Size = new System.Drawing.Size(399, 51);
            this.drawSelect.TabIndex = 4;
            this.drawSelect.TabStop = false;
            this.drawSelect.Text = "What to draw:";
            // 
            // arcs
            // 
            this.arcs.AutoSize = true;
            this.arcs.Location = new System.Drawing.Point(122, 20);
            this.arcs.Name = "arcs";
            this.arcs.Size = new System.Drawing.Size(59, 17);
            this.arcs.TabIndex = 2;
            this.arcs.TabStop = true;
            this.arcs.Text = "Beziers";
            this.arcs.UseVisualStyleBackColor = true;
            this.arcs.CheckedChanged += new System.EventHandler(this.arcs_CheckedChanged);
            // 
            // lines
            // 
            this.lines.AutoSize = true;
            this.lines.Location = new System.Drawing.Point(65, 20);
            this.lines.Name = "lines";
            this.lines.Size = new System.Drawing.Size(50, 17);
            this.lines.TabIndex = 1;
            this.lines.TabStop = true;
            this.lines.Text = "Lines";
            this.lines.UseVisualStyleBackColor = true;
            this.lines.CheckedChanged += new System.EventHandler(this.lines_CheckedChanged);
            // 
            // noise
            // 
            this.noise.AutoSize = true;
            this.noise.Checked = true;
            this.noise.Location = new System.Drawing.Point(7, 20);
            this.noise.Name = "noise";
            this.noise.Size = new System.Drawing.Size(52, 17);
            this.noise.TabIndex = 0;
            this.noise.TabStop = true;
            this.noise.Text = "Noise";
            this.noise.UseVisualStyleBackColor = true;
            this.noise.CheckedChanged += new System.EventHandler(this.noise_CheckedChanged);
            // 
            // random
            // 
            this.random.AutoSize = true;
            this.random.Location = new System.Drawing.Point(188, 20);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(65, 17);
            this.random.TabIndex = 3;
            this.random.TabStop = true;
            this.random.Text = "Random";
            this.random.UseVisualStyleBackColor = true;
            this.random.CheckedChanged += new System.EventHandler(this.random_CheckedChanged);
            // 
            // randomColor
            // 
            this.randomColor.AutoSize = true;
            this.randomColor.Location = new System.Drawing.Point(152, 95);
            this.randomColor.Name = "randomColor";
            this.randomColor.Size = new System.Drawing.Size(106, 17);
            this.randomColor.TabIndex = 5;
            this.randomColor.Text = "Randomize Color";
            this.randomColor.UseVisualStyleBackColor = true;
            this.randomColor.Visible = false;
            // 
            // saveImage
            // 
            this.saveImage.Location = new System.Drawing.Point(93, 12);
            this.saveImage.Name = "saveImage";
            this.saveImage.Size = new System.Drawing.Size(75, 23);
            this.saveImage.TabIndex = 6;
            this.saveImage.Text = "Save Image";
            this.saveImage.UseVisualStyleBackColor = true;
            this.saveImage.Click += new System.EventHandler(this.saveImage_Click);
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.DefaultExt = "png";
            this.saveImageDialog.Filter = "PNG-Image|*.png|JPEG-Image|*.jpg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 549);
            this.Controls.Add(this.saveImage);
            this.Controls.Add(this.randomColor);
            this.Controls.Add(this.drawSelect);
            this.Controls.Add(this.Jumprange);
            this.Controls.Add(this.jumRange);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.picOutput);
            this.Name = "Form1";
            this.Text = "Random Image Generator";
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
            this.drawSelect.ResumeLayout(false);
            this.drawSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOutput;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.MaskedTextBox jumRange;
        private System.Windows.Forms.Label Jumprange;
        private System.Windows.Forms.GroupBox drawSelect;
        private System.Windows.Forms.RadioButton noise;
        private System.Windows.Forms.RadioButton lines;
        private System.Windows.Forms.RadioButton arcs;
        private System.Windows.Forms.RadioButton random;
        private System.Windows.Forms.CheckBox randomColor;
        private System.Windows.Forms.Button saveImage;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
    }
}

