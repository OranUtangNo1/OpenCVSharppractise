namespace ImageProccessingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PicBox_SelectedImage = new PictureBox();
            PicBox_ProcessedImage = new PictureBox();
            Btn_SelectImage = new Button();
            btn_Save = new Button();
            ChkBox_Contrast = new CheckBox();
            ChkBox_GrayScale = new CheckBox();
            ChkBox_Saturation = new CheckBox();
            ScBar_Contrast = new HScrollBar();
            ScBar_Saturation = new HScrollBar();
            Btn_ProcessImage = new Button();
            Btn_Clear = new Button();
            ChkBox_Gauss = new CheckBox();
            ScBar_Gauss = new HScrollBar();
            ScBar_Brightness = new HScrollBar();
            ChkBox_Brightness = new CheckBox();
            ChkBox_NegaPosi = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)PicBox_SelectedImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicBox_ProcessedImage).BeginInit();
            SuspendLayout();
            // 
            // PicBox_SelectedImage
            // 
            PicBox_SelectedImage.BorderStyle = BorderStyle.FixedSingle;
            PicBox_SelectedImage.Location = new Point(33, 73);
            PicBox_SelectedImage.Name = "PicBox_SelectedImage";
            PicBox_SelectedImage.Size = new Size(340, 340);
            PicBox_SelectedImage.TabIndex = 0;
            PicBox_SelectedImage.TabStop = false;
            // 
            // PicBox_ProcessedImage
            // 
            PicBox_ProcessedImage.BorderStyle = BorderStyle.FixedSingle;
            PicBox_ProcessedImage.Location = new Point(399, 73);
            PicBox_ProcessedImage.Name = "PicBox_ProcessedImage";
            PicBox_ProcessedImage.Size = new Size(340, 340);
            PicBox_ProcessedImage.TabIndex = 1;
            PicBox_ProcessedImage.TabStop = false;
            // 
            // Btn_SelectImage
            // 
            Btn_SelectImage.BackColor = SystemColors.ButtonShadow;
            Btn_SelectImage.Location = new Point(33, 419);
            Btn_SelectImage.Name = "Btn_SelectImage";
            Btn_SelectImage.Size = new Size(109, 36);
            Btn_SelectImage.TabIndex = 2;
            Btn_SelectImage.Text = "Select Image";
            Btn_SelectImage.UseVisualStyleBackColor = false;
            Btn_SelectImage.Click += Btn_SelectImage_Click;
            // 
            // btn_Save
            // 
            btn_Save.AccessibleRole = AccessibleRole.None;
            btn_Save.BackColor = SystemColors.ButtonShadow;
            btn_Save.Location = new Point(399, 419);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(109, 36);
            btn_Save.TabIndex = 3;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = false;
            btn_Save.Click += btn_Save_Click;
            // 
            // ChkBox_Contrast
            // 
            ChkBox_Contrast.AutoSize = true;
            ChkBox_Contrast.Location = new Point(33, 563);
            ChkBox_Contrast.Name = "ChkBox_Contrast";
            ChkBox_Contrast.Size = new Size(70, 19);
            ChkBox_Contrast.TabIndex = 4;
            ChkBox_Contrast.Text = "Contrast";
            ChkBox_Contrast.UseVisualStyleBackColor = true;
            // 
            // ChkBox_GrayScale
            // 
            ChkBox_GrayScale.AutoSize = true;
            ChkBox_GrayScale.Location = new Point(33, 487);
            ChkBox_GrayScale.Name = "ChkBox_GrayScale";
            ChkBox_GrayScale.Size = new Size(77, 19);
            ChkBox_GrayScale.TabIndex = 5;
            ChkBox_GrayScale.Text = "GrayScale";
            ChkBox_GrayScale.UseVisualStyleBackColor = true;
            // 
            // ChkBox_Saturation
            // 
            ChkBox_Saturation.AutoSize = true;
            ChkBox_Saturation.Location = new Point(33, 649);
            ChkBox_Saturation.Name = "ChkBox_Saturation";
            ChkBox_Saturation.Size = new Size(80, 19);
            ChkBox_Saturation.TabIndex = 6;
            ChkBox_Saturation.Text = "Saturation";
            ChkBox_Saturation.UseVisualStyleBackColor = true;
            // 
            // ScBar_Contrast
            // 
            ScBar_Contrast.LargeChange = 5;
            ScBar_Contrast.Location = new Point(151, 563);
            ScBar_Contrast.Maximum = 50;
            ScBar_Contrast.Minimum = 1;
            ScBar_Contrast.Name = "ScBar_Contrast";
            ScBar_Contrast.Size = new Size(357, 19);
            ScBar_Contrast.TabIndex = 7;
            ScBar_Contrast.Value = 25;
            // 
            // ScBar_Saturation
            // 
            ScBar_Saturation.LargeChange = 5;
            ScBar_Saturation.Location = new Point(151, 649);
            ScBar_Saturation.Maximum = 50;
            ScBar_Saturation.Minimum = 1;
            ScBar_Saturation.Name = "ScBar_Saturation";
            ScBar_Saturation.Size = new Size(357, 19);
            ScBar_Saturation.TabIndex = 9;
            ScBar_Saturation.Value = 25;
            // 
            // Btn_ProcessImage
            // 
            Btn_ProcessImage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Btn_ProcessImage.Location = new Point(578, 563);
            Btn_ProcessImage.Name = "Btn_ProcessImage";
            Btn_ProcessImage.Size = new Size(130, 61);
            Btn_ProcessImage.TabIndex = 10;
            Btn_ProcessImage.Text = "Process Image";
            Btn_ProcessImage.UseVisualStyleBackColor = true;
            Btn_ProcessImage.Click += Btn_ProcessImage_Click;
            // 
            // Btn_Clear
            // 
            Btn_Clear.BackColor = SystemColors.ButtonShadow;
            Btn_Clear.Location = new Point(264, 419);
            Btn_Clear.Name = "Btn_Clear";
            Btn_Clear.Size = new Size(109, 36);
            Btn_Clear.TabIndex = 11;
            Btn_Clear.Text = "Clear";
            Btn_Clear.UseVisualStyleBackColor = false;
            Btn_Clear.Click += Btn_Clear_Click;
            // 
            // ChkBox_Gauss
            // 
            ChkBox_Gauss.AutoSize = true;
            ChkBox_Gauss.Location = new Point(33, 522);
            ChkBox_Gauss.Name = "ChkBox_Gauss";
            ChkBox_Gauss.Size = new Size(57, 19);
            ChkBox_Gauss.TabIndex = 12;
            ChkBox_Gauss.Text = "Gauss";
            ChkBox_Gauss.UseVisualStyleBackColor = true;
            // 
            // ScBar_Gauss
            // 
            ScBar_Gauss.LargeChange = 1;
            ScBar_Gauss.Location = new Point(151, 522);
            ScBar_Gauss.Maximum = 10;
            ScBar_Gauss.Minimum = 1;
            ScBar_Gauss.Name = "ScBar_Gauss";
            ScBar_Gauss.Size = new Size(357, 19);
            ScBar_Gauss.TabIndex = 13;
            ScBar_Gauss.Value = 6;
            // 
            // ScBar_Brightness
            // 
            ScBar_Brightness.LargeChange = 5;
            ScBar_Brightness.Location = new Point(151, 605);
            ScBar_Brightness.Maximum = 50;
            ScBar_Brightness.Minimum = 1;
            ScBar_Brightness.Name = "ScBar_Brightness";
            ScBar_Brightness.Size = new Size(357, 19);
            ScBar_Brightness.TabIndex = 15;
            ScBar_Brightness.Value = 25;
            // 
            // ChkBox_Brightness
            // 
            ChkBox_Brightness.AutoSize = true;
            ChkBox_Brightness.Location = new Point(33, 605);
            ChkBox_Brightness.Name = "ChkBox_Brightness";
            ChkBox_Brightness.Size = new Size(81, 19);
            ChkBox_Brightness.TabIndex = 14;
            ChkBox_Brightness.Text = "Brightness";
            ChkBox_Brightness.UseVisualStyleBackColor = true;
            // 
            // ChkBox_NegaPosi
            // 
            ChkBox_NegaPosi.AutoSize = true;
            ChkBox_NegaPosi.Location = new Point(151, 487);
            ChkBox_NegaPosi.Name = "ChkBox_NegaPosi";
            ChkBox_NegaPosi.Size = new Size(76, 19);
            ChkBox_NegaPosi.TabIndex = 16;
            ChkBox_NegaPosi.Text = "NegaPosi";
            ChkBox_NegaPosi.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 736);
            Controls.Add(ChkBox_NegaPosi);
            Controls.Add(ScBar_Brightness);
            Controls.Add(ChkBox_Brightness);
            Controls.Add(ScBar_Gauss);
            Controls.Add(ChkBox_Gauss);
            Controls.Add(Btn_Clear);
            Controls.Add(Btn_ProcessImage);
            Controls.Add(ScBar_Saturation);
            Controls.Add(ScBar_Contrast);
            Controls.Add(ChkBox_Saturation);
            Controls.Add(ChkBox_GrayScale);
            Controls.Add(ChkBox_Contrast);
            Controls.Add(btn_Save);
            Controls.Add(Btn_SelectImage);
            Controls.Add(PicBox_ProcessedImage);
            Controls.Add(PicBox_SelectedImage);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PicBox_SelectedImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicBox_ProcessedImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PicBox_SelectedImage;
        private PictureBox PicBox_ProcessedImage;
        private Button Btn_SelectImage;
        private Button btn_Save;
        private CheckBox ChkBox_Contrast;
        private CheckBox ChkBox_GrayScale;
        private CheckBox ChkBox_Saturation;
        private HScrollBar ScBar_Contrast;
        private HScrollBar ScBar_Saturation;
        private Button Btn_ProcessImage;
        private Button Btn_Clear;
        private CheckBox ChkBox_Gauss;
        private HScrollBar ScBar_Gauss;
        private HScrollBar ScBar_Brightness;
        private CheckBox ChkBox_Brightness;
        private CheckBox ChkBox_NegaPosi;
    }
}
