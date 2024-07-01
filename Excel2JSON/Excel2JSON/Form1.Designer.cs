namespace Excel2JSON
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
            btnCalistir = new Button();
            txtPath = new TextBox();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            btnDosyaSec = new Button();
            SuspendLayout();
            // 
            // btnCalistir
            // 
            btnCalistir.Location = new Point(26, 171);
            btnCalistir.Name = "btnCalistir";
            btnCalistir.Size = new Size(213, 45);
            btnCalistir.TabIndex = 0;
            btnCalistir.Text = "Çalıştır";
            btnCalistir.UseVisualStyleBackColor = true;
            btnCalistir.Click += btnCalistir_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(26, 102);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(213, 27);
            txtPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 69);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDosyaSec
            // 
            btnDosyaSec.Location = new Point(26, 135);
            btnDosyaSec.Name = "btnDosyaSec";
            btnDosyaSec.Size = new Size(213, 30);
            btnDosyaSec.TabIndex = 3;
            btnDosyaSec.Text = "Dosya Seç";
            btnDosyaSec.UseVisualStyleBackColor = true;
            btnDosyaSec.Click += btnDosyaSec_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 426);
            Controls.Add(btnDosyaSec);
            Controls.Add(label1);
            Controls.Add(txtPath);
            Controls.Add(btnCalistir);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalistir;
        private TextBox txtPath;
        private Label label1;
        private OpenFileDialog openFileDialog1;
        private Button btnDosyaSec;
    }
}
